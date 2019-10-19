namespace WebPlex.Web.Mvc.UI {
	using System.Web.Mvc;

	using WebPlex.Web.Mvc.UI.Builders;

	public static class HtmlHelperExtensions {
		public static AnchorBuilder Anchor(this HtmlHelper htmlHelper) {
			return new AnchorBuilder();
		}

		public static ButtonBuilder Button(this HtmlHelper htmlHelper) {
			return new ButtonBuilder();
		}

		public static ButtonGroupBuilder ButtonGroup(this HtmlHelper htmlHelper) {
			return new ButtonGroupBuilder();
		}

		public static AlertBuilder Alert(this HtmlHelper htmlHelper) {
			return new AlertBuilder();
		}

		public static AlertGroupBuilder AlertGroup(this HtmlHelper htmlHelper) {
			return new AlertGroupBuilder();
		}
	}
}