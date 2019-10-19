namespace WebPlex.Web.Mvc.UI.Builders {
	using WebPlex.Web.Mvc.UI.Components;

	public sealed class DescriptionBuilder : BuilderBase<DescriptionComponent, DescriptionBuilder> {
		protected override void Init() {
			base.Init();

			SetAttribute("name", "description");
		}

		public DescriptionBuilder Text(object value) {
			return SetAttribute("content", value, true, true);
		}
	}
}