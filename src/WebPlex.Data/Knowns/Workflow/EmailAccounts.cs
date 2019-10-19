namespace WebPlex.Data.Knowns.Workflow {
	using WebPlex.Core.Builders;
	using WebPlex.Data.Builders;

	public static class EmailAccounts {
		public static readonly Constant NoReply = new InternalKey(ea => NoReply);
		public static readonly Constant Info = new InternalKey(ea => Info);
		public static readonly Constant Contact = new InternalKey(ea => Contact);
		public static readonly Constant Support = new InternalKey(ea => Support);
		public static readonly Constant Sales = new InternalKey(ea => Sales);
	}
}