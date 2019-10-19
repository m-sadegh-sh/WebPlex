namespace WebPlex.Web.Mvc {
	using System;
	using System.Reflection;
	using System.Web.Mvc;

	using WebPlex.Core;

	public sealed class FormValueRequiredAttribute : ActionMethodSelectorAttribute {
		private readonly string[] _submitButtonNames;
		private readonly FormValueRequirement _requirement;

		public FormValueRequiredAttribute(params string[] submitButtonNames) : this(FormValueRequirement.Equal, submitButtonNames) {}

		public FormValueRequiredAttribute(FormValueRequirement requirement, params string[] submitButtonNames) {
			_submitButtonNames = submitButtonNames;
			_requirement = requirement;
		}

		public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo) {
			foreach (var buttonName in _submitButtonNames) {
				var value = string.Empty;

				switch (_requirement) {
					case FormValueRequirement.Equal:
						value = controllerContext.HttpContext.Request.Form[buttonName];

						break;

					case FormValueRequirement.StartsWith:
						foreach (var formValue in controllerContext.HttpContext.Request.Form.AllKeys) {
							if (!formValue.StartsWith(buttonName, StringComparison.InvariantCultureIgnoreCase))
								continue;

							value = controllerContext.HttpContext.Request.Form[formValue];
							break;
						}
						break;

					default:
						throw new NotSupportedEnumException(_requirement);
				}

				if (!string.IsNullOrEmpty(value))
					return true;
			}

			return false;
		}
	}
}