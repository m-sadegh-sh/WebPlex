namespace WebPlex.Web.Mvc.Html {
	using System.Web;
	using System.Web.Mvc;

	using CuttingEdge.Conditions;

	using Microsoft.Security.Application;

	public static class SecurityExtensions {
		public static IHtmlString GetSafeHtml(this HtmlHelper helper, string unsafeHtml) {
			Condition.Requires(helper).IsNotNull();

			if (unsafeHtml == null)
				return null;

			var safeHtml = Sanitizer.GetSafeHtml(unsafeHtml);

			return MvcHtmlString.Create(safeHtml);
		}
	}
}