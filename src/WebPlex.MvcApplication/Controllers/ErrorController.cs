namespace WebPlex.MvcApplication.Controllers {
	using System.Web;
	using System.Web.Mvc;

	using WebPlex.MvcApplication.Models.Error;
	using WebPlex.Resources;

	public partial class ErrorController : PlexControllerBase {
		[HttpGet]
		public virtual ActionResult Index(string catchAll, HttpException exception) {
			var model = new ErrorModel();

			var httpCode = exception.GetHttpCode();

			switch (httpCode) {
				case 403:
					Response.StatusCode = model.ErrorNum = 403;
					model.Heading = Messages.Errors_Error403;
					model.Message = Messages.Errors_Error403Description;
					break;

				case 404:
					Response.StatusCode = model.ErrorNum = 404;
					model.Heading = Messages.Errors_Error404;
					model.Message = Messages.Errors_Error404Description;
					break;

				case 500:
					Response.StatusCode = model.ErrorNum = 500;
					model.Heading = Messages.Errors_Error500;
					model.Message = Messages.Errors_Error500Description;
					break;

				case 503:
					Response.StatusCode = model.ErrorNum = 503;
					model.Heading = Messages.Errors_Error503;
					model.Message = string.Format(Messages.Errors_Error503Description, Application.CloseReason);
					break;
			}

			Response.TrySkipIisCustomErrors = true;

			if (IsPartialNeeded)
				return Json(model, JsonRequestBehavior.AllowGet);

			return View(model);
		}
	}
}