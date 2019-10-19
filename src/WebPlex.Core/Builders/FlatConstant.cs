namespace WebPlex.Core.Builders {
	public class FlatConstant : Constant {
		private readonly string _key;

		public FlatConstant(string key) {
			_key = key;
		}

		protected override string BuildKey() {
			return _key;
		}
	}
}