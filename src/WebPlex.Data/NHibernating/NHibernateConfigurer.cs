namespace WebPlex.Data.NHibernating {
	using System;
	using System.Data;
	using System.Linq;
	using System.Reflection;

	using Autofac;

	using NHibernate;
	using NHibernate.Cfg;
	using NHibernate.Cfg.MappingSchema;
	using NHibernate.Connection;
	using NHibernate.Dialect;
	using NHibernate.Driver;
	using NHibernate.Mapping.ByCode;
	using NHibernate.Tool.hbm2ddl;
	using NHibernate.Validator.Cfg;
	using NHibernate.Validator.Cfg.Loquacious;
	using NHibernate.Validator.Engine;

	using WebPlex.Core.Domain.Entities.Configuration;
	using WebPlex.Core.Domain.Entities.Contents;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;
	using WebPlex.Data.NHibernating.Conventions;

	public sealed class NHibernateConfigurer {
		public Action<ModelMapper> AutoMappingOverride { set; get; }

		public string ConnectionString { set; get; }

		public string DbSchemaOutputFile { set; get; }

		public bool DropTablesCreateDbSchema { set; get; }

		public Assembly MappingAssembly { set; get; }

		public Func<Type, bool> MappingTypeFinder { get; set; }

		public string OutputXmlMappingsFile { set; get; }

		public bool ShowLogs { set; get; }

		public ValidatorEngine ValidatorEngine { get; set; }

		public Configuration Configuration { get; private set; }

		public ISessionFactory SetUpSessionFactory() {
			Configuration = ReadConfigFromCacheFileOrBuildIt();

			var sessionFactory = Configuration.BuildSessionFactory();

			if (DropTablesCreateDbSchema)
				ConfirmDatabaseMatchesMappings.TryValidateAndUpdateDatabaseSchema(Configuration, sessionFactory);

			return sessionFactory;
		}

		private Configuration ReadConfigFromCacheFileOrBuildIt() {
			var configurationFileCache = EngineContext.Current.Resolve<ConfigurationFileCache>(new TypedParameter(typeof (Assembly), MappingAssembly));

			var configuration = configurationFileCache.LoadFromFile();

			if (configuration == null) {
				configuration = BuildConfiguration();

				configurationFileCache.SaveToFile(configuration);
			}

			return configuration;
		}

		private Configuration BuildConfiguration() {
			var configuration = InitConfiguration();
			var hbmMapping = GetHbmMappings();

			configuration.AddDeserializedMapping(hbmMapping, null);

			InjectValidationsAndFieldLengths(configuration);

			SchemaMetadataUpdater.QuoteTableAndColumns(configuration);

			return configuration;
		}

		private Configuration InitConfiguration() {
			var configuration = new Configuration();
			configuration.SessionFactoryName(GetType().Assembly.GetName().FullName);

			configuration.DataBaseIntegration(dicp => {
				                                  dicp.ConnectionProvider<DriverConnectionProvider>();
				                                  dicp.Dialect<MsSql2008Dialect>();
				                                  dicp.Driver<Sql2008ClientDriver>();
				                                  dicp.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
				                                  dicp.IsolationLevel = IsolationLevel.ReadCommitted;
				                                  dicp.ConnectionString = ConnectionString;
				                                  dicp.Timeout = 10;
				                                  dicp.BatchSize = DbConstants.BatchSize;

				                                  if (ShowLogs) {
					                                  dicp.LogFormattedSql = true;
					                                  dicp.LogSqlInConsole = true;
					                                  dicp.AutoCommentSql = false;
				                                  }
			                                  });

			return configuration;
		}

		private HbmMapping GetHbmMappings() {
			var mapper = new ConventionModelMapper();

			var mappings = MappingAssembly.GetExportedTypes().Where(MappingTypeFinder).ToList();

			mapper.AddMappings(mappings);

			mapper.ApplyNamingConventions();

			if (AutoMappingOverride != null)
				AutoMappingOverride(mapper);

			var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

			ShowOutputXmlMappings(mapping);

			return mapping;
		}

		private void ShowOutputXmlMappings(HbmMapping mapping) {
			if (!ShowLogs)
				return;

			var output = mapping.AsString();

			Console.WriteLine(output);
		}

		private void InjectValidationsAndFieldLengths(Configuration configuration) {
			var fluentConfiguration = new FluentConfiguration();

			RegisterValidationDefinitions(fluentConfiguration);

			fluentConfiguration.IntegrateWithNHibernate.ApplyingDDLConstraints().And.RegisteringListeners();

			ValidatorEngine.Configure(fluentConfiguration);

			configuration.Initialize(ValidatorEngine);
		}

		private static void RegisterValidationDefinitions(IFluentConfiguration configuration) {
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ApplicationSettings>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<CloudSettings>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<ContactFormSettings>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<SettingEntity>>());

			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<SubscriptionEntity>>());

			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<BannedIpEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<LogEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PermissionGroupEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<PermissionEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<RoleEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<UserAttributeEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<UserEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<MembershipEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<OAuthEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<OAuthTokenEntity>>());

			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<EmailAccountEntity>>());
			configuration.Register(EngineContext.Current.Resolve<IValidationDefinition<QueuedMailEntity>>());
		}
	}
}