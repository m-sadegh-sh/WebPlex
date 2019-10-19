namespace WebPlex.MvcApplication.Areas.Admin {
	using System.Web.Mvc;

	using WebPlex.Web.Mvc;

	public class AdminAreaRegistration : AreaRegistration {
		public override string AreaName {
			get { return "Admin"; }
		}

		public override void RegisterArea(AreaRegistrationContext context) {
			context.MapT4Route("AdminDashboard", "admin/dashboard", T4Routes.Admin.Dashboard.Index());

			context.MapT4Route("AdminConfigurationEnsureDefaultUser", "admin/configuration/ensure-default-user", T4Routes.Admin.Configuration.EnsureDefaultUser());

			context.MapT4Route("AdminConfigurationEnsureDefaultSettings", "admin/configuration/ensure-default-settings", T4Routes.Admin.Configuration.EnsureDefaultSettings());
		}
	}
}