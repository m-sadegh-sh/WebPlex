namespace WebPlex.Web.Mvc.UI.Components {
	using System.Collections.Generic;

	public sealed class NavbarComponent : ComponentBase {
		private IList<NavItemComponent> _items;

		public IList<NavItemComponent> Items {
			get { return _items ?? (_items = new List<NavItemComponent>()); }
			set { _items = value; }
		}
	}
}