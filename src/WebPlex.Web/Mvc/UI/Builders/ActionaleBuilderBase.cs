namespace WebPlex.Web.Mvc.UI.Builders {
	using WebPlex.Core.Extensions;
	using WebPlex.Web.Mvc.UI.Components;

	public abstract class ActionaleBuilderBase<T, TBuilder> : BuilderBase<T, TBuilder> where T : ActionableComponentBase {
		protected override void Init() {
			base.Init();

			AddCssClass("btn");
		}

		public TBuilder Block {
			get { return AddCssClass("btn-block"); }
		}

		public TBuilder Primary {
			get { return AddCssClass("btn-primary"); }
		}

		public TBuilder Danger {
			get { return AddCssClass("btn-danger"); }
		}

		public TBuilder Warning {
			get { return AddCssClass("btn-warning"); }
		}

		public TBuilder Success {
			get { return AddCssClass("btn-success"); }
		}

		public TBuilder Info {
			get { return AddCssClass("btn-info"); }
		}

		public TBuilder Inverse {
			get { return AddCssClass("btn-inverse"); }
		}

		public TBuilder Mini {
			get { return AddCssClass("btn-mini"); }
		}

		public TBuilder Small {
			get { return AddCssClass("btn-small"); }
		}

		public TBuilder Large {
			get { return AddCssClass("btn-large"); }
		}

		public TBuilder Text(object value) {
			Component.Text = value.ToStringOrDefault();
			return (TBuilder) (object) this;
		}
	}
}