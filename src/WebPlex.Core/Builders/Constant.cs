namespace WebPlex.Core.Builders {
	public abstract class Constant {
		private bool _keyGenerated;
		private string _key;
		protected const string KeySeparator = ".";

		public virtual bool CanHandleResources {
			get { return false; }
		}

		protected abstract string BuildKey();

		public override string ToString() {
			if (!_keyGenerated) {
				_key = BuildKey();
				_keyGenerated = true;
			}

			return _key;
		}

		public static implicit operator string(Constant value) {
			return value.ToString();
		}

		public static implicit operator Constant(string value) {
			return new FlatConstant(value);
		}
	}
}