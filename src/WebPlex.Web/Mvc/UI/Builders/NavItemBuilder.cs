namespace WebPlex.Web.Mvc.UI.Builders {
	using System;
	using System.Web.Mvc;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Core.Extensions;
	using WebPlex.Web.Mvc.UI.Components;

	public sealed class NavItemBuilder : BuilderCollectionBase<NavItemComponent, NavItemBuilder> {
		public NavItemBuilder Result(ActionResult value) {
			Component.Result = value;
			return this;
		}

		public NavItemBuilder Text(object value) {
			Component.Text = value.ToStringOrDefault();
			return this;
		}

		public NavItemBuilder AddDivider(bool value) {
			Component.AddDivider = value;
			return this;
		}

		public NavItemBuilder SubItems(Action<ChildrenExpression<NavItemBuilder>> action) {
			Children(action).ForEach(b => Component.SubItems.Add(b.Component));
			return this;
		}
	}
}