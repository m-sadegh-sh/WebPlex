namespace WebPlex.Web.Mvc {
	using System;
	using System.Security.Principal;
	using System.Web;
	using System.Web.Mvc;

	using CuttingEdge.Conditions;

	using WebPlex.Core.Engine;
	using WebPlex.Web.Mvc.UI;
	using WebPlex.Web.Routing;

	public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter {
		private readonly bool _authorize;

		public static Lazy<ActionResult> RedirectResult { private get; set; }

		public AuthorizeAttribute() {
			_authorize = true;
		}

		public AuthorizeAttribute(bool authorize) {
			_authorize = authorize;
		}

		public virtual void OnAuthorization(AuthorizationContext context) {
			Condition.Requires(context).IsNotNull();

			if (OutputCacheAttribute.IsChildActionCacheActive(context))
				throw new InvalidOperationException();

			if (AuthorizeCore(context.HttpContext)) {
				var cache = context.HttpContext.Response.Cache;

				cache.SetProxyMaxAge(TimeSpan.Zero);
				cache.AddValidationCallback(CacheValidateHandler, null);
			} else
				HandleUnauthorizedRequest(context);
		}

		protected bool AuthorizeCore(HttpContextBase context) {
			Condition.Requires(context).IsNotNull();

			if (!_authorize)
				return true;

			return true; // IsAuthorized(context);
		}

		private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus) {
			validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
		}

		protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase context) {
			Condition.Requires(context).IsNotNull();

			return !AuthorizeCore(context) ? HttpValidationStatus.IgnoreThisRequest : HttpValidationStatus.Valid;
		}

		protected virtual bool IsAuthorized(HttpContextBase context) {
			return EngineContext.Current.Resolve<IIdentity>().IsAuthenticated;
		}

		protected void HandleUnauthorizedRequest(AuthorizationContext context) {
			Condition.Requires(context).IsNotNull();

			var currentValues = context.RouteData.GetT4RouteValueDictionary();
			var result = RedirectResult.Value;
			var expectedValues = result.GetRouteValueDictionary();

			if (RouteHelpers.Equals(currentValues, expectedValues))
				return;

			var url = EngineContext.Current.Resolve<UrlHelper>().Action(result);

			context.Result = new RedirectResult(url);
		}
	}
}