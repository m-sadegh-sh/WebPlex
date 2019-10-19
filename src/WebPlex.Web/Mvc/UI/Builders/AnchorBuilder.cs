namespace WebPlex.Web.Mvc.UI.Builders {
	using System.Web.Mvc;

	using WebPlex.Web.Mvc.UI.Components;

	public sealed class AnchorBuilder : ActionaleBuilderBase<AnchorComponent, AnchorBuilder> {
		public AnchorBuilder Result(ActionResult value) {
			Component.Result = value;
			return this;
		}
	}
}