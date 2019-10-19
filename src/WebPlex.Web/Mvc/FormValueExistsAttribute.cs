namespace WebPlex.Web.Mvc {
	using System.Web.Mvc;

	public sealed class FormValueExistsAttribute : ActionFilterAttribute {
		private readonly string _name;
		private readonly string _value;
		private readonly string _parameterName;

		public FormValueExistsAttribute(string name, string value, string parameterName) {
			_name = name;
			_value = value;
			_parameterName = parameterName;
		}

		public override void OnActionExecuting(ActionExecutingContext actionExecutingContext) {
			var formValue = actionExecutingContext.RequestContext.HttpContext.Request.Form[_name];

			actionExecutingContext.ActionParameters[_parameterName] = !string.IsNullOrEmpty(formValue) && formValue.ToLower().Equals(_value.ToLower());
		}
	}
}