namespace WebPlex.Web.Routing {
	using System;
	using System.IO;
	using System.Web.Routing;

	public sealed class LowercaseRoute : Route {
		public LowercaseRoute(string url, IRouteHandler routeHandler) : base(url, routeHandler) {}

		public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults, routeHandler) {}

		public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler) : base(url, defaults, constraints, routeHandler) {}

		public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler) : base(url, defaults, constraints, dataTokens, routeHandler) {}

		public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values) {
			var virtualPathData = base.GetVirtualPath(requestContext, values);

			if (virtualPathData == null)
				return null;

			var virtualPath = virtualPathData.VirtualPath;
			var num = virtualPath.LastIndexOf("?", StringComparison.Ordinal);

			if (num != 0) {
				if (num > 0) {
					var path = virtualPath.Substring(0, num).ToLowerInvariant();

					var trailingSlashNeeded = string.IsNullOrEmpty(Path.GetExtension(path)) && !path.EndsWith("/");
					if (trailingSlashNeeded)
						path += "/";

					var query = virtualPath.Substring(num);

					virtualPath = path + query;
				} else {
					virtualPath = virtualPath.ToLowerInvariant();

					var trailingSlashNeeded = string.IsNullOrEmpty(Path.GetExtension(virtualPath)) && !virtualPath.EndsWith("/");
					if (trailingSlashNeeded)
						virtualPath += "/";
				}

				virtualPathData.VirtualPath = virtualPath;
			}

			return virtualPathData;
		}
	}
}