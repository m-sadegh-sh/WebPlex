namespace WebPlex.Core.Configuration {
	using System;
	using System.Configuration;
	using System.Linq.Expressions;
	using System.Xml;

	using CuttingEdge.Conditions;

	using Inflector;

	using TB.ComponentModel;

	using Utilities.Reflection.ExtensionMethods;

	public abstract class ConfigBase<TConfig> : IConfigurationSectionHandler where TConfig : ConfigBase<TConfig> {
		public abstract object Create(object parent, object configContext, XmlNode section);

		protected static T Load<T>() where T : class, new() {
			var configName = typeof (T).Name.Camelize();

			var config = ConfigurationManager.GetSection(configName) as T;

			return config ?? new T();
		}

		protected TProperty GetAttribute<TProperty>(XmlNode section, Expression<Func<TConfig, TProperty>> property, TProperty defaultValue = default(TProperty)) {
			Condition.Requires(section).IsNotNull();
			Condition.Requires(property).IsNotNull();

			var value = GetAttributeCore(section, property);

			if (value.CanConvertTo<TProperty>())
				return value.ConvertTo<TProperty>();

			return defaultValue;
		}

		private static object GetAttributeCore<TProperty>(XmlNode section, Expression<Func<TConfig, TProperty>> property) {
			if (section.Attributes != null) {
				var name = property.GetPropertyName().Camelize();
				var attribute = section.Attributes[name];

				if (attribute != null)
					return attribute.Value;
			}

			return null;
		}
	}
}