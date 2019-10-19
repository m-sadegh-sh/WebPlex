namespace WebPlex.Web.Mvc.UI.Builders {
	using WebPlex.Core.Extensions;
	using WebPlex.Web.Mvc.UI.Components;

	public sealed class TitleBuilder : BuilderBase<TitleComponent, TitleBuilder> {
		public TitleBuilder Add(object value) {
			Component.Add(value.ToStringOrDefault());
			return this;
		}
	}
}