namespace WebPlex.Data {
	using NHibernate;

	public sealed class SessionProvider : ISessionProvider {
		private readonly ISessionFactory _sessionFactory;

		public SessionProvider(ISessionFactory sessionFactory) {
			_sessionFactory = sessionFactory;
		}

		public ISession Create() {
			var session = _sessionFactory.OpenSession();

			return session;
		}

		public IStatelessSession CreateStateless() {
			var session = _sessionFactory.OpenStatelessSession();
			session.SetBatchSize(DbConstants.BatchSize);

			return session;
		}
	}
}