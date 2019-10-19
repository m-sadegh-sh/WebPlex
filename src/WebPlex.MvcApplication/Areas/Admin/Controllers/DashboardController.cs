namespace WebPlex.MvcApplication.Areas.Admin.Controllers {
	using System.Web.Mvc;

	using WebPlex.MvcApplication.Controllers;
	using WebPlex.Web.Mvc;

	[AdminRequired]
	[RequireHttps]
	public partial class DashboardController : PlexControllerBase {
		[HttpGet]
		public virtual ActionResult Index() {
			return View();
		}
	}
}