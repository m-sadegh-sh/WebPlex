namespace WebPlex.MvcApplication {
	using System;
	using System.Web;
	using System.Web.Mvc;

	public class PlexApplication : HttpApplication {
		private void Application_Start() {
			MvcHandler.DisableMvcResponseHeader = true;
		}

		private void Application_BeginRequest(object sender, EventArgs e) {}

		private void Application_Error(object sender, EventArgs e) {}
	}
}