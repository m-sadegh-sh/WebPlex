namespace WebPlex.Data.NHibernating {
	using System.Data;

	using NHibernate;
	using NHibernate.Cfg;
	using NHibernate.Tool.hbm2ddl;

	public static class ConfirmDatabaseMatchesMappings {
		public static void TryValidateAndUpdateDatabaseSchema(Configuration configuration, ISessionFactory sessionFactory) {
			try {
				ValidateDatabaseSchemaAgainstMappings(sessionFactory);
			} catch {
				ExportDbSchema(configuration, sessionFactory.OpenSession().Connection);
			}
		}

		private static void ValidateDatabaseSchemaAgainstMappings(ISessionFactory sessionFactory) {
			using (var session = sessionFactory.OpenSession()) {
				var classMetadatas = sessionFactory.GetAllClassMetadata();

				foreach (var classMetadata in classMetadatas)
					session.CreateCriteria(classMetadata.Value.GetMappedClass(EntityMode.Poco)).SetMaxResults(0).List();
			}
		}

		private static void ExportDbSchema(Configuration configuration, IDbConnection dbConnection) {
			var schemaExport = new SchemaExport(configuration);

			schemaExport.Execute(false, true, false, dbConnection, null);
		}
	}
}