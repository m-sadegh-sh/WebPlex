namespace WebPlex.Web.Modules {
	using System;
	using System.Web;

	public sealed class HeaderCleanerModule : IHttpModule {
		public void Init(HttpApplication context) {
			context.PreSendRequestHeaders += OnPreSendRequestHeaders;
		}

		private static void OnPreSendRequestHeaders(object sender, EventArgs e) {
			var context = ((HttpApplication) sender).Context;

			context.Response.Headers.Remove("Server");
		}

		public void Dispose() {}
	}
}