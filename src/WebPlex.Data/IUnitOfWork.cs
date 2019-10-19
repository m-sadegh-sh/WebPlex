namespace WebPlex.Data {
	using System;

	public interface IUnitOfWork : IDisposable {
		void BeginTransaction();
		void EndTransaction();
		void RollBack();
	}
}