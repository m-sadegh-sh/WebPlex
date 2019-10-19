namespace WebPlex.Data {
	using Autofac;
	using Autofac.Integration.Mvc;

	using NHibernate.Validator.Engine;

	using WebPlex.Core.Configuration;
	using WebPlex.Data.Mapping;
	using WebPlex.Data.NHibernating;

	public sealed class DataTypesModule : Module {
		protected override void Load(ContainerBuilder builder) {
			builder.RegisterType<ConfigurationFileCache>().InstancePerHttpRequest();
			builder.RegisterType<ValidatorEngine>().SingleInstance();

			builder.Register(cc => new NHibernateConfigurer {
					ConnectionString = cc.Resolve<PlexConfig>().ConnectionString,
					DropTablesCreateDbSchema = true,
					MappingAssembly = typeof (EntityMapBase<>).Assembly,
					MappingTypeFinder = t => t.IsMappingType(),
					ValidatorEngine = cc.Resolve<ValidatorEngine>()
			}).SingleInstance();

			builder.Register(cc => cc.Resolve<NHibernateConfigurer>().SetUpSessionFactory()).SingleInstance();
			builder.RegisterType<SessionProvider>().As<ISessionProvider>().SingleInstance();
			builder.RegisterType<ActiveSessionManager>().As<IActiveSessionManager>().InstancePerHttpRequest();
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
			builder.Register(cc => cc.Resolve<ISessionProvider>().CreateStateless()).InstancePerDependency();
		}
	}
}