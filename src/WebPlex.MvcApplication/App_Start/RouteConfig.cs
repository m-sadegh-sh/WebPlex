using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (RouteConfig), "RegisterRoutes")]

namespace WebPlex.MvcApplication.App_Start {
	using System.Net;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;

	using WebPlex.Web.Mvc;

	public class RouteConfig {
		public static void RegisterRoutes() {
			var routes = RouteTable.Routes;

			routes.Clear();

			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapT4Route("RedirectToIndex", "", T4Routes.Home.RedirectToIndex());

			routes.MapT4Route("Home", "home", T4Routes.Home.Index());

			routes.MapT4Route("About", "about", T4Routes.Home.About());

			routes.MapT4Route("Contact", "contact", T4Routes.Home.Contact());

			routes.MapT4Route("Blog", "blog", T4Routes.Blog.Index());

			routes.MapT4Route("SignIn", "sign-in", T4Routes.Authenticate.SignIn());

			routes.MapT4Route("ExternalSignIn", "sign-in/external", T4Routes.Authenticate.ExternalSignIn());

			routes.MapT4Route("ExternalSignInCallback", "sign-in/external-callback", T4Routes.Authenticate.ExternalSignInCallback());

			routes.MapT4Route("SignOut", "sign-out", T4Routes.Authenticate.SignOut());

			routes.MapT4Route("SignUp", "sign-up", T4Routes.Authenticate.SignUp());

			routes.MapT4Route("ResetPassword", "reset-password", T4Routes.Authenticate.ResetPassword());

			routes.MapT4Route("SetOrChangePassword", "set-or-change-password", T4Routes.Authenticate.SetOrChangePassword());

			routes.MapT4Route("SetPassword", "set-password", T4Routes.Authenticate.SetPassword());

			routes.MapT4Route("ChangePassword", "change-password", T4Routes.Authenticate.ChangePassword());

			routes.MapT4Route("Disassociate", "disassociate", T4Routes.Authenticate.Disassociate());

			AreaRegistration.RegisterAllAreas();

			routes.MapRoute("InternalCalls", "{Controller}/{Action}");

			routes.MapRoute("Error", "{Controller}/{Action}/{*catchAll}", T4Routes.Error.Index(null, new HttpException((int) HttpStatusCode.NotFound, null)));
		}
	}
}