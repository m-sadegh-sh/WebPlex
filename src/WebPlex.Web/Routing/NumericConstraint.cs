namespace WebPlex.Web.Routing {
	using System.Web;
	using System.Web.Routing;

	public sealed class NumericConstraint : IRouteConstraint {
		private readonly bool _isOptional;
		private readonly int? _minValue;
		private readonly int? _maxValue;

		public NumericConstraint(bool isOptional, int? minValue = null, int? maxValue = null) {
			_isOptional = isOptional;
			_minValue = minValue;
			_maxValue = maxValue;
		}

		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
			var value = values[parameterName] as string;

			if (_isOptional && value == null)
				return true;

			int number;
			var isValid = int.TryParse(value, out number);

			if (!isValid)
				return false;

			if (_minValue != null && number <= _minValue)
				return false;

			if (_maxValue != null && number > _maxValue)
				return false;

			return true;
		}
	}
}