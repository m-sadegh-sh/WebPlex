namespace WebPlex.Web.Mvc.UI.Components {
	using System.Collections.Generic;

	public sealed class NavItemComponent : AnchorComponent {
		private IList<NavItemComponent> _subItems;

		public bool AddDivider { get; set; }

		public IList<NavItemComponent> SubItems {
			get { return _subItems ?? (_subItems = new List<NavItemComponent>()); }
			set { _subItems = value; }
		}
	}
}