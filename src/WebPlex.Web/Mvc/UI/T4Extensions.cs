namespace WebPlex.Web.Mvc.UI {
	using System.Web.Mvc;
	using System.Web.Routing;

	using CuttingEdge.Conditions;

	using WebPlex.Web.Routing;

	public static class T4Extensions {
		public static bool IsCurrent(this HtmlHelper htmlHelper, ActionResult result) {
			Condition.Requires(htmlHelper).IsNotNull();

			if (result == null)
				return false;

			var currentValues = htmlHelper.ViewContext.RouteData.GetT4RouteValueDictionary();
			var expectedValues = result.GetRouteValueDictionary();

			return RouteHelpers.Equals(currentValues, expectedValues);
		}

		public static RouteValueDictionary GetT4RouteValueDictionary(this RouteData routeData) {
			return (RouteValueDictionary) routeData.Values["RouteValueDictionary"];
		}
	}
}