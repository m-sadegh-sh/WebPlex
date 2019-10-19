namespace WebPlex.Web.Mvc {
	using System.Text;
	using System.Web.Mvc;

	public sealed class MvcHtmlStringBuilder {
		private readonly StringBuilder _stringBuilder;

		public MvcHtmlStringBuilder() {
			_stringBuilder = new StringBuilder();
		}

		public void Append(string value) {
			_stringBuilder.Append(value);
		}

		public void Append(MvcHtmlString value) {
			_stringBuilder.Append(value.ToHtmlString());
		}

		public new MvcHtmlString ToString() {
			return MvcHtmlString.Create(_stringBuilder.ToString());
		}
	}
}