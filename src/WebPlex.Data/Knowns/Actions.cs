namespace WebPlex.Data.Knowns {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class Actions {
		public static readonly Constant Default = new ActionKey(a => Default);

		public static readonly Constant List = new ActionKey(a => List);
		public static readonly Constant Details = new ActionKey(a => Details);
		public static readonly Constant New = new ActionKey(a => New);
		public static readonly Constant Edit = new ActionKey(a => Edit);
		public static readonly Constant Save = new ActionKey(a => Save);

		public static readonly Constant[] NonPluralizables = new[] {Default, List, Details, New, Edit, Save};
	}
}