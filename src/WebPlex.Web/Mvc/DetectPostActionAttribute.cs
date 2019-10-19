namespace WebPlex.Web.Mvc {
	using System.Web.Mvc;

	using WebPlex.Core;

	public sealed class DetectPostActionAttribute : ActionFilterAttribute {
		private readonly string _parameterName;

		public DetectPostActionAttribute(string parameterName) {
			_parameterName = parameterName;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			var formValue = filterContext.RequestContext.HttpContext.Request.Form["post-actions"];
			PostAction postAction;

			switch (formValue) {
				case "publish-all":
					postAction = PostAction.PublishAll;
					break;

				case "unpublish-all":
					postAction = PostAction.UnpublishAll;
					break;

				case "temporarily-delete-all":
					postAction = PostAction.TemporarilyDeleteAll;
					break;

				case "permanently-delete-all":
					postAction = PostAction.PermanentlyDeleteAll;
					break;

				case "undelete-all":
					postAction = PostAction.UnDeleteAll;
					break;

				default:
					throw new NotSupportedEnumException(formValue);
			}

			filterContext.ActionParameters[_parameterName] = postAction;
		}
	}
}