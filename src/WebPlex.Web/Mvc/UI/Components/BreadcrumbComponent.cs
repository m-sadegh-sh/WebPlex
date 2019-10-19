namespace WebPlex.Web.Mvc.UI.Components {
	using System.Collections.Generic;

	public sealed class BreadcrumbComponent : ComponentBase {
		private IList<AnchorComponent> _items;

		public IList<AnchorComponent> Items {
			get { return _items ?? (_items = new List<AnchorComponent>()); }
			set { _items = value; }
		}
	}
}