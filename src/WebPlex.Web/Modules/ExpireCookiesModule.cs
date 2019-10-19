namespace WebPlex.Web.Modules {
	using System;
	using System.Linq;
	using System.Web;

	public sealed class ExpireCookiesModule : IHttpModule {
		public void Init(HttpApplication context) {
			context.EndRequest += OnEndRequest;
		}

		private static void OnEndRequest(object sender, EventArgs e) {
			var context = ((HttpApplication) sender).Context;
			var cookies = context.Response.Cookies;

			foreach (var cookie in cookies.Cast<HttpCookie>())
				cookie.Expires = DateTime.Now.AddYears(-9999);
		}

		public void Dispose() {}
	}
}