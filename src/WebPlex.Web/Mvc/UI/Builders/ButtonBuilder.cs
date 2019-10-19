namespace WebPlex.Web.Mvc.UI.Builders {
	using WebPlex.Web.Mvc.UI.Components;

	public sealed class ButtonBuilder : ActionaleBuilderBase<ButtonComponent, ButtonBuilder> {
		public ButtonBuilder Submit {
			get { return SetAttribute("type", "submit", true); }
		}

		public ButtonBuilder Name(object value) {
			return SetAttribute("name", value, true);
		}

		public ButtonBuilder Value(object value) {
			return SetAttribute("value", value, true);
		}
	}
}