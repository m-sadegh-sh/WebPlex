namespace WebPlex.Data.Builders {
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Text;

	using Utilities.Reflection.ExtensionMethods;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	public abstract class ExpressionConstant<T> : Constant {
		private readonly IDictionary<string, bool> _parameters = new Dictionary<string, bool>();

		protected ExpressionConstant(params Expression<Func<T, object>>[] properties) {
			if (properties.IsEmpty())
				return;

			foreach (var property in properties)
				_parameters.Add(property.GetPropertyName(), true);
		}

		protected override string BuildKey() {
			var keyBuilder = new StringBuilder();

			var pattern = BuildPattern();
			keyBuilder.Append(pattern);

			if (!_parameters.IsEmpty()) {
				var index = 0;

				foreach (var parameter in _parameters) {
					keyBuilder.Append(parameter.Key);

					if (parameter.Value)
						keyBuilder.AppendFormat("{{{0}}}", index);

					if (index < _parameters.Count - 1)
						keyBuilder.Append(KeySeparator);

					if (parameter.Value)
						index++;
				}
			}

			return keyBuilder.ToString();
		}

		protected virtual string BuildPattern() {
			return typeof (T).Name.ToUpperInvariant() + KeySeparator;
		}
	}
}