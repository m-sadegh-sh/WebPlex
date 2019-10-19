namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	using Microsoft.Security.Application;

	using WebPlex.Core.Extensions;
	using WebPlex.Web.Mvc.UI.Components;

	public abstract class BuilderBase<T, TBuilder> : IBuilder where T : IComponent {
		protected BuilderBase() {
			Component = Activator.CreateInstance<T>();
			Init();
		}

		protected virtual void Init() {}

		public TBuilder Id(object value) {
			return SetAttribute("id", value, true);
		}

		public TBuilder AddCssClassIf(bool condition, object value) {
			if (condition)
				return AddCssClass(value);

			return (TBuilder) (object) this;
		}

		public TBuilder AddCssClass(object value) {
			return MergeAttribute("class", value);
		}

		public TBuilder AddDataIf(bool condition, string key, object value) {
			if (condition)
				return AddData(key, value);

			return (TBuilder) (object) this;
		}

		public TBuilder AddData(string key, object value) {
			return SetAttribute("data-" + key, value, true);
		}

		protected TBuilder MergeAttribute(string key, object value) {
			var values = value.ToStringOrDefault().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

			object obj;
			var currentValue = "";
			if (Component.Attributes.TryGetValue(key, out obj))
				currentValue = obj.ToString();

			foreach (var val in values)
				currentValue += " " + val;

			return SetAttribute(key, currentValue, true);
		}

		protected TBuilder SetAttribute(string key, object value, bool replaceExisting = false, bool encode = false) {
			if (!Component.Attributes.ContainsKey(key) || replaceExisting) {
				var val = value.ToStringOrDefault().TrimOrDefault();

				if (encode)
					val = Sanitizer.GetSafeHtml(val);

				if (!string.IsNullOrWhiteSpace(val))
					Component.Attributes[key] = val;
			}

			return (TBuilder) (object) this;
		}

		protected T Component { get; private set; }

		public static implicit operator T(BuilderBase<T, TBuilder> value) {
			return value.Component;
		}
	}
}