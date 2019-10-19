namespace WebPlex.Data {
	using NHibernate;

	using WebPlex.Core;
	using WebPlex.Core.Caching;

	public sealed class ActiveSessionManager : DisposableBase, IActiveSessionManager {
		private const string SESSION_KEY = "_currentSession";

		private readonly ICacheManager _cacheWrapper;
		private readonly ISessionProvider _provider;

		public ActiveSessionManager(ICacheManager cacheWrapper, ISessionProvider provider) {
			_cacheWrapper = cacheWrapper;
			_provider = provider;
		}

		public ISession GetActiveSession() {
			if (Current == null)
				Current = _provider.Create();

			return Current;
		}

		public void ClearActiveSession() {
			Current = null;
		}

		public bool HasActiveSession {
			get { return Current != null; }
		}

		public void RenewSession() {
			ClearActiveSession();
			GetActiveSession();
		}

		protected override void CoreDispose(bool disposeManagedResources) {
			var session = Current;

			if (session != null) {
				session.Dispose();
				ClearActiveSession();
			}
		}

		private ISession Current {
			get { return _cacheWrapper.Get<ISession>(SESSION_KEY); }
			set {
				if (value == null)
					_cacheWrapper.Remove(SESSION_KEY);
				else
					_cacheWrapper.Add(SESSION_KEY, value);
			}
		}
	}
}