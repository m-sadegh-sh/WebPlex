namespace WebPlex.Web.Routing {
	using System.Web;
	using System.Web.Routing;

	using WebPlex.Core;
	using WebPlex.Core.Extensions;

	public sealed class SanitizeConstraint : IRouteConstraint {
		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
			var value = values[parameterName].ToStringOrDefault();

			return PatternValidator.IsValidSlug(value);
		}
	}
}