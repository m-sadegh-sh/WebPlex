namespace WebPlex.Web.Modules {
	using System;
	using System.Net;
	using System.Web;
	using System.Web.Mvc;

	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;

	public sealed class AppClosedModule : IHttpModule {
		public static Lazy<ActionResult> NonRestrictedResult { private get; set; }

		public void Init(HttpApplication context) {
			context.AuthenticateRequest += OnAuthenticateRequest;
		}

		private static void OnAuthenticateRequest(object sender, EventArgs e) {
			var context = ((HttpApplication) sender).Context;
			var request = context.Request;

			if (!EngineContext.Current.Resolve<ApplicationSettings>().IsClosed)
				return;

			var urlHelper = EngineContext.Current.Resolve<UrlHelper>();

			var currentUrl = request.Url.AbsolutePath;
			var allowedUrl = new Uri(urlHelper.Action(NonRestrictedResult.Value)).AbsolutePath;

			if (!string.Equals(currentUrl, allowedUrl, StringComparison.InvariantCultureIgnoreCase))
				throw new HttpException((int) HttpStatusCode.ServiceUnavailable, null);
		}

		public void Dispose() {}
	}
}