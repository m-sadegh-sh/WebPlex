namespace WebPlex.MvcApplication.Controllers {
	using System;
	using System.Web.Mvc;

	using WebPlex.Web.Mvc.UI.Components;

	[ChildActionOnly]
	public partial class ComponentsController : PlexControllerBase {
		public virtual PartialViewResult Title(TitleComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Keywords(KeywordsComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Description(DescriptionComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Anchor(AnchorComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Alert(AlertComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Button(ButtonComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Breadcrumb(BreadcrumbComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult AlertGroup(AlertGroupComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult ButtonGroup(ButtonGroupComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult Navbar(NavbarComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}

		public virtual PartialViewResult NavItem(NavItemComponent component) {
			if (component == null)
				throw new ArgumentNullException("component");

			return PartialView(component);
		}
	}
}