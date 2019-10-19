namespace WebPlex.Web.Mvc {
	using System;
	using System.Web.Mvc;

	using CuttingEdge.Conditions;

	public sealed class NotCacheableAttribute : ActionFilterAttribute {
		public override void OnActionExecuting(ActionExecutingContext context) {
			Condition.Requires(context).IsNotNull();

			context.HttpContext.Response.Cache.SetProxyMaxAge(new TimeSpan(0));
		}
	}
}