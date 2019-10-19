namespace WebPlex.Data.Knowns {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class Constraints {
		public static Constant Int32 = new ConstraintKey(@"\d+$");
	}
}