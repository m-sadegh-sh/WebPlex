namespace WebPlex.Web.Mvc {
	using System.Web;

	using WebPlex.Core.Engine;
	using WebPlex.Data.Knowns.Security;
	using WebPlex.Web.Security;

	public sealed class AdminRequiredAttribute : AuthorizeAttribute {
		protected override bool IsAuthorized(HttpContextBase context) {
			if (!base.IsAuthorized(context))
				return false;

			var authorizationService = EngineContext.Current.Resolve<IAuthorizationService>();

			return authorizationService.IsInRole(Roles.Administrators);
		}
	}
}