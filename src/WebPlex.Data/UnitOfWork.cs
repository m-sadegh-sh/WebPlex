namespace WebPlex.Data {
	using System;

	using NHibernate;

	using WebPlex.Core;

	public sealed class UnitOfWork : DisposableBase, IUnitOfWork {
		private readonly IActiveSessionManager _activeSessionManager;
		private ITransaction _transaction;

		public UnitOfWork(IActiveSessionManager activeSessionManager) {
			_activeSessionManager = activeSessionManager;
		}

		public void BeginTransaction() {
			if (_transaction != null)
				throw new InvalidOperationException("Transaction already started; nested transactions are not supported.");

			_transaction = _activeSessionManager.GetActiveSession().BeginTransaction();
		}

		public void EndTransaction() {
			if (_transaction == null)
				throw new InvalidOperationException("No active transaction found.");

			if (!_transaction.IsActive)
				throw new InvalidOperationException("This transaction is no longer active.");

			try {
				_transaction.Commit();
			} catch (Exception) {
				RollBack();
			}
		}

		public void RollBack() {
			if (_transaction == null)
				throw new InvalidOperationException("No active transaction found.");

			_transaction.Rollback();
		}

		protected override void CoreDispose(bool disposeManagedResources) {
			if (_transaction != null)
				_transaction.Dispose();

			_activeSessionManager.Dispose();
		}
	}
}