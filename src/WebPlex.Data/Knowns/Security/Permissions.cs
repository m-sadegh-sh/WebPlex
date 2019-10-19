namespace WebPlex.Data.Knowns.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class Permissions {
		public static readonly Constant Home = new InternalKey(p => Home);
		public static readonly Constant Dashboard = new InternalKey(p => Dashboard);
	}
}