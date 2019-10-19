namespace WebPlex.Web.Mvc {
	using System.Linq;
	using System.Web.Mvc;
	using System.Web.Routing;

	public static class AreaRegistrationContextExtensions {
		public static Route MapT4Route(this AreaRegistrationContext context, string name, string url, ActionResult result) {
			return context.MapT4Route(name, url, result.GetRouteValueDictionary(), null, null);
		}

		public static Route MapT4Route(this AreaRegistrationContext context, string name, string url, ActionResult result, object constraints) {
			return context.MapT4Route(name, url, result.GetRouteValueDictionary(), constraints, null);
		}

		public static Route MapT4Route(this AreaRegistrationContext context, string name, string url, ActionResult result, string[] namespaces) {
			return context.MapT4Route(name, url, result.GetRouteValueDictionary(), null, namespaces);
		}

		public static Route MapT4Route(this AreaRegistrationContext context, string name, string url, ActionResult result, object constraints, string[] namespaces) {
			return context.MapT4Route(name, url, result.GetRouteValueDictionary(), constraints, namespaces);
		}

		private static Route MapT4Route(this AreaRegistrationContext context, string name, string url, object defaults, object constraints, string[] namespaces) {
			if (namespaces == null && context.Namespaces != null)
				namespaces = context.Namespaces.ToArray();

			var route = context.Routes.MapT4Route(name, url, defaults, constraints, namespaces);

			route.DataTokens["area"] = context.AreaName;
			route.DataTokens["UseNamespaceFallback"] = namespaces == null || namespaces.Length == 0;

			return route;
		}
	}
}