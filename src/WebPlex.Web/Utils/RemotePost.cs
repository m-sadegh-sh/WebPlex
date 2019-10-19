namespace WebPlex.Web.Utils {
	using System.Collections.Specialized;
	using System.Web;
	using System.Web.Helpers;

	using CuttingEdge.Conditions;

	using WebPlex.Core.Engine;

	public sealed class RemotePost {
		public RemotePost(string url, string method) {
			Condition.Requires(url).IsNotNullOrEmpty();
			Condition.Requires(method).IsNotNullOrEmpty();

			Url = url;
			Method = method;
			FormName = Crypto.GenerateSalt(16);
			Params = new NameValueCollection();
		}

		public string Url { get; set; }
		public string Method { get; set; }
		public string FormName { get; private set; }
		public NameValueCollection Params { get; private set; }

		public void Add(string name, string value) {
			Condition.Requires(name).IsNotNullOrEmpty();
			Condition.Requires(value).IsNotNullOrEmpty();

			Params.Add(name, value);
		}

		public void Post() {
			var httpContext = EngineContext.Current.Resolve<HttpContextBase>();

			httpContext.Response.Clear();
			httpContext.Response.Write("<html><head>");
			httpContext.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
			httpContext.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));

			foreach (string key in Params.Keys)
				httpContext.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", HttpUtility.HtmlEncode(key), HttpUtility.HtmlEncode(Params[key])));

			httpContext.Response.Write("</form>");
			httpContext.Response.Write("</body></html>");
			httpContext.Response.End();
		}
	}
}