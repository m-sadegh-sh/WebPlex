namespace WebPlex.Web.Mvc.UI.Builders {
	using WebPlex.Core.Extensions;
	using WebPlex.Web.Mvc.UI.Components;

	public sealed class AlertBuilder : BuilderBase<AlertComponent, AlertBuilder> {
		public AlertBuilder Error {
			get { return AddCssClass("alert-error"); }
		}

		public AlertBuilder Success {
			get { return AddCssClass("alert-success"); }
		}

		public AlertBuilder Info {
			get { return AddCssClass("alert-info"); }
		}

		public AlertBuilder Blocked {
			get { return AddCssClass("alert-block"); }
		}

		public AlertBuilder Title(object value) {
			Component.Title = value.ToStringOrDefault();
			return this;
		}

		public AlertBuilder Message(object value) {
			Component.Message = value.ToStringOrDefault();
			return this;
		}
	}
}