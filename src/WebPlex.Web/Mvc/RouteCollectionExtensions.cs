namespace WebPlex.Web.Mvc {
	using System.Web.Mvc;
	using System.Web.Routing;

	using CuttingEdge.Conditions;

	using WebPlex.Web.Routing;

	public static class RouteCollectionExtensions {
		public static Route MapT4Route(this RouteCollection routes, string name, string url, ActionResult result) {
			return routes.MapT4Route(name, url, result.GetRouteValueDictionary(), null, null);
		}

		public static Route MapT4Route(this RouteCollection routes, string name, string url, ActionResult result, object constraints) {
			return routes.MapT4Route(name, url, result.GetRouteValueDictionary(), constraints, null);
		}

		public static Route MapT4Route(this RouteCollection routes, string name, string url, ActionResult result, string[] namespaces) {
			return routes.MapT4Route(name, url, result.GetRouteValueDictionary(), null, namespaces);
		}

		public static Route MapT4Route(this RouteCollection routes, string name, string url, ActionResult result, object constraints, string[] namespaces) {
			return routes.MapT4Route(name, url, result.GetRouteValueDictionary(), constraints, namespaces);
		}

		internal static Route MapT4Route(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces) {
			Condition.Requires(routes).IsNotNull();
			Condition.Requires(url).IsNotNull();

			url = RouteHelpers.UrlFormatter(url);

			var route = new LowercaseRoute(url, new MvcRouteHandler()) {
					Defaults = defaults.Convert(),
					Constraints = constraints.Convert(),
					DataTokens = new RouteValueDictionary()
			};

			if (namespaces != null && namespaces.Length > 0)
				route.DataTokens["Namespaces"] = namespaces;

			routes.Add(name, route);

			return route;
		}
	}
}