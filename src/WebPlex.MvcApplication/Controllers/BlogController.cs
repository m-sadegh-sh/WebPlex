namespace WebPlex.MvcApplication.Controllers {
	using System.Web.Mvc;

	public partial class BlogController : PlexControllerBase {
		[HttpGet]
		public virtual ActionResult Index() {
			return View();
		}
	}
}