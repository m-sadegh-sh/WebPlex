namespace WebPlex.Web.Mvc {
	using System.Web.Mvc;

	using WebPlex.Core.Engine;
	using WebPlex.Data;

	public sealed class TransactionalAttribute : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			EngineContext.Current.Resolve<IUnitOfWork>().BeginTransaction();
		}

		public override void OnActionExecuted(ActionExecutedContext filterContext) {
			EngineContext.Current.Resolve<IUnitOfWork>().EndTransaction();
		}
	}
}