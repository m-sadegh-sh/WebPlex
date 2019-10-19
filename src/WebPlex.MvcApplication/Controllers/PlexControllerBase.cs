namespace WebPlex.MvcApplication.Controllers {
	using System;
	using System.Collections.Generic;
	using System.ServiceModel.Syndication;
	using System.Web.Mvc;
	using System.Web.Routing;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Web.Mvc.Feed;

	using IOFile = System.IO.File;

	public abstract class PlexControllerBase : Controller {
		protected override void Initialize(RequestContext requestContext) {
			base.Initialize(requestContext);

			Logger = EngineContext.Current.Resolve<ILogService>();
			WorkContext = EngineContext.Current.Resolve<IWorkContext>();
			WebHelper = EngineContext.Current.Resolve<IWebHelper>();
			Application = EngineContext.Current.Resolve<ApplicationSettings>();
		}

		protected ILogService Logger { get; private set; }

		protected IWorkContext WorkContext { get; private set; }

		protected IWebHelper WebHelper { get; private set; }

		protected ApplicationSettings Application { get; private set; }

		protected bool IsPartialNeeded {
			get { return ControllerContext.IsChildAction || Request.IsAjaxRequest(); }
		}

		protected EmptyResult Empty() {
			return new EmptyResult();
		}

		protected FeedResult Feed(string title, IList<SyndicationItem> items, string language = "fa-IR") {
			return new FeedResult(title, items, language);
		}

		protected ActionResult RedirectToLocal(string returnUrl, ActionResult secondaryReturnResult) {
			if (Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);

			return RedirectToRoute(secondaryReturnResult.GetRouteValueDictionary());
		}

		protected FileStreamResult Pdf(string fileName, string fileDownloadName) {
			var resumeFile = IOFile.OpenRead(fileName);

			return File(resumeFile, "application/pdf", fileDownloadName);
		}

		protected virtual void WarningAlert(string message, bool persistForTheNextRequest = true) {
			AddAlert("warning", message, persistForTheNextRequest);
		}

		protected virtual void ErrorAlert(string message, bool persistForTheNextRequest = true) {
			AddAlert("error", message, persistForTheNextRequest);
		}

		protected virtual void ExceptionAlert(Exception exception, bool persistForTheNextRequest = true) {
			AddAlert("error", exception.Message, persistForTheNextRequest);
		}

		protected virtual void SuccessAlert(string message, bool persistForTheNextRequest = true) {
			AddAlert("success", message, persistForTheNextRequest);
		}

		protected virtual void InfoAlert(string message, bool persistForTheNextRequest = true) {
			AddAlert("info", message, persistForTheNextRequest);
		}

		private void AddAlert(string alertType, string message, bool persistForTheNextRequest) {
			var alertKey = string.Format("alerts.{0}", alertType);

			IDictionary<string, object> dictionary;

			if (persistForTheNextRequest)
				dictionary = TempData;
			else
				dictionary = ViewData;

			if (dictionary[alertKey] == null)
				dictionary[alertKey] = new List<string>();

			((List<string>) dictionary[alertKey]).Add(message);
		}
	}
}