namespace WebPlex.Web.Mvc {
	using System.Threading;
	using System.Web.Mvc;

	using WebPlex.Core;
	using WebPlex.Core.Engine;

	public sealed class CultureFilterAttribute : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			var request = filterContext.HttpContext.Request;

			if (EngineContext.Current.Resolve<IWebHelper>().IsStaticResource(request))
				return;

			var currentCulture = EngineContext.Current.Resolve<IWorkContext>().CurrentCulture;

			if (currentCulture != null) {
				Thread.CurrentThread.CurrentCulture = currentCulture;
				Thread.CurrentThread.CurrentUICulture = currentCulture;
			}
		}
	}
}