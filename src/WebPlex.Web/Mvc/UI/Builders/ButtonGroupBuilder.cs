namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Web.Mvc.UI.Components;

	public sealed class ButtonGroupBuilder : BuilderCollectionBase<ButtonGroupComponent, ButtonGroupBuilder> {
		protected override void Init() {
			base.Init();

			AddCssClass("btn-group");
		}

		public ButtonGroupBuilder Block {
			get { return AddCssClass("btn-block"); }
		}

		public ButtonGroupBuilder Single {
			get { return AddData("toggle", "button"); }
		}

		public ButtonGroupBuilder CheckBox {
			get { return AddData("toggle", "buttons-checkbox"); }
		}

		public ButtonGroupBuilder RadioBox {
			get { return AddData("toggle", "buttons-radio"); }
		}

		public ButtonGroupBuilder Buttons(Action<ChildrenExpression<ButtonBuilder>> action) {
			Children(action).ForEach(b => Component.Add(b));
			return this;
		}
	}
}