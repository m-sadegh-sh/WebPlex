namespace WebPlex.Data.Knowns.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class Groups {
		public static readonly Constant Website = new InternalKey(g => Website);
		public static readonly Constant Administration = new InternalKey(g => Administration);
	}
}