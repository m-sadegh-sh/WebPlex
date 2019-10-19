namespace WebPlex.MvcApplication.Controllers {
	using System.Web.Mvc;

	using WebPlex.Web.Mvc.Feed;

	public partial class FeedController : PlexControllerBase {
		[HttpGet]
		public virtual FeedResult Index() {
			return null;
		}
	}
}