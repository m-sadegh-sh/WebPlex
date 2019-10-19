namespace WebPlex.Data {
	using NHibernate;

	public interface ISessionProvider {
		ISession Create();
		IStatelessSession CreateStateless();
	}
}