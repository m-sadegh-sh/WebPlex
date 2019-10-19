namespace WebPlex.Web.Mvc.UI.Builders {
	using WebPlex.Web.Mvc.UI.Components;

	public sealed class KeywordsBuilder : BuilderBase<KeywordsComponent, KeywordsBuilder> {
		protected override void Init() {
			base.Init();

			SetAttribute("name", "keywords");
		}

		public KeywordsBuilder Text(object value) {
			return SetAttribute("content", value, true, true);
		}
	}
}