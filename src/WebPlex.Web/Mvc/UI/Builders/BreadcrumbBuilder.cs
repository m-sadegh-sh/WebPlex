namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Web.Mvc.UI.Components;

	public sealed class BreadcrumbBuilder : BuilderCollectionBase<BreadcrumbComponent, BreadcrumbBuilder> {
		protected override void Init() {
			base.Init();

			AddCssClass("breadcrumb");
		}

		public BreadcrumbBuilder Items(Action<ChildrenExpression<AnchorBuilder>> action) {
			Children(action).ForEach(b => Component.Items.Add(b));
			return this;
		}
	}
}