namespace WebPlex.Web.Mvc.UI.Components {
	using System.Collections.Generic;
	using System.Web;

	public interface IComponent {
		IDictionary<string, object> Attributes { get; }
		IHtmlString WriteAttributes();
		IHtmlString WriteAttribute(string key);
	}
}