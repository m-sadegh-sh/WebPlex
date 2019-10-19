namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Web.Mvc.UI.Components;

	public sealed class AlertGroupBuilder : BuilderCollectionBase<AlertGroupComponent, AlertGroupBuilder> {
		public AlertGroupBuilder Alerts(Action<ChildrenExpression<AlertBuilder>> action) {
			Children(action).ForEach(b => Component.Add(b));
			return this;
		}
	}
}