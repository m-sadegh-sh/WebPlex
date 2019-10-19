namespace WebPlex.Data.Knowns.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class Roles {
		public static readonly Constant Users = new InternalKey(r => Users);
		public static readonly Constant Administrators = new InternalKey(r => Administrators);
	}
}