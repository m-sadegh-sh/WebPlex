namespace WebPlex.Web.Mvc.Html {
	using System.Web;
	using System.Web.Mvc;

	using CuttingEdge.Conditions;

	public static class HtmlExtensions {
		public static IHtmlString Concat(this HtmlHelper helper, params IHtmlString[] values) {
			Condition.Requires(helper).IsNotNull();
			Condition.Requires(values).IsNotNull();

			var concat = string.Join<IHtmlString>("", values);

			return MvcHtmlString.Create(concat);
		}

		public static IHtmlString If(this HtmlHelper helper, bool condition, string output) {
			Condition.Requires(helper).IsNotNull();

			if (condition)
				return MvcHtmlString.Create(output);

			return null;
		}

		public static IHtmlString If(this HtmlHelper helper, bool condition, IHtmlString html) {
			Condition.Requires(helper).IsNotNull();

			if (condition)
				return html;

			return null;
		}
	}
}