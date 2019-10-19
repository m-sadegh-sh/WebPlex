namespace WebPlex.Data.Builders {
	using WebPlex.Core.Builders;

	public class LabelKey<T> : Constant {
		public override bool CanHandleResources {
			get { return true; }
		}

		protected override string BuildKey() {
			return null;
		}
	}
}