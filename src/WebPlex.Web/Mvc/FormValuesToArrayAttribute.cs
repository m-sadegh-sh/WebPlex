namespace WebPlex.Web.Mvc {
	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;

	using TB.ComponentModel;

	using WebPlex.Core.Extensions;

	public sealed class FormValuesToArrayAttribute : ActionFilterAttribute {
		private readonly Type _type;
		private readonly string _parameterName;

		public FormValuesToArrayAttribute(Type type, string parameterName) {
			_type = type;
			_parameterName = parameterName;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext) {
			var dictionary = filterContext.RequestContext.HttpContext.Request.Form.ToDictionary();

			var acceptedFormValues = new List<object>();

			foreach (var item in dictionary) {
				var value = item.Value;

				if (string.IsNullOrEmpty(value))
					continue;

				var idx = value.IndexOf(",", StringComparison.Ordinal);

				if (idx > -1)
					value = value.Substring(0, idx);

				bool selected;

				if (!bool.TryParse(value, out selected) || !selected)
					continue;

				if (item.Key.CanConvert(_type))
					acceptedFormValues.Add(item.Key.Convert(_type));
			}

			filterContext.ActionParameters[_parameterName] = acceptedFormValues.ToArray();
		}
	}
}