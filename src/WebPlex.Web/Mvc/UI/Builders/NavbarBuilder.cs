namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Web.Mvc.UI.Components;

	public sealed class NavbarBuilder : BuilderCollectionBase<NavbarComponent, NavbarBuilder> {
		public NavbarBuilder Items(Action<ChildrenExpression<NavItemBuilder>> action) {
			Children(action).ForEach(b => Component.Items.Add(b));
			return this;
		}
	}
}