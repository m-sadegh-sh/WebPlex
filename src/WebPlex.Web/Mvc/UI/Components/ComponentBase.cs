namespace WebPlex.Web.Mvc.UI.Components {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Web;
	using System.Web.Mvc;

	public abstract class ComponentBase : IComponent {
		public IDictionary<string, object> Attributes { get; private set; }

		protected ComponentBase() {
			Attributes = new SortedDictionary<string, object>(StringComparer.Ordinal);
		}

		public IHtmlString WriteAttributes() {
			var output = new StringBuilder();

			foreach (var attribute in Attributes.Where(kvp => kvp.Value != null))
				output.AppendFormat("{0}=\"{1}\"", attribute.Key, attribute.Value);

			return MvcHtmlString.Create(output.ToString());
		}

		public IHtmlString WriteAttribute(string key) {
			object obj;

			if (!Attributes.TryGetValue(key, out obj))
				return null;

			var value = obj.ToString().Trim();
			if (string.IsNullOrEmpty(value))
				return null;

			return MvcHtmlString.Create(string.Format("{0}=\"{1}\"", key, value));
		}
	}
}