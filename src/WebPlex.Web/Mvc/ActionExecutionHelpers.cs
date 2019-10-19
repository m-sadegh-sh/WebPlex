namespace WebPlex.Web.Mvc {
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;

	using CuttingEdge.Conditions;

	using WebPlex.Web.Routing;

	public static class ActionExecutionHelpers {
		public static void ExecuteAction(this HttpContext context, ActionResult result) {
			new HttpContextWrapper(context).ExecuteAction(result);
		}

		public static void ExecuteAction(this HttpContextBase context, ActionResult result) {
			Condition.Requires(context).IsNotNull();
			Condition.Requires(result).IsNotNull();

			var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
			var controllerName = result.GetT4MVCResult().Controller;
			var routeValues = result.GetRouteValueDictionary();

			var routeData = new RouteData();
			routeData.Values.Overwrite(routeValues);

			var requestContext = new RequestContext(context, routeData);

			var controller = controllerFactory.CreateController(requestContext, controllerName);

			controller.Execute(requestContext);
		}
	}
}