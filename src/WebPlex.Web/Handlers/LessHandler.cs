namespace WebPlex.Web.Handlers {
	using System.IO;
	using System.Web;

	using WebPlex.Core;
	using WebPlex.Core.Engine;
	using WebPlex.Web.Optimization;

	public sealed class LessHandler : IHttpHandler {
		public void ProcessRequest(HttpContext context) {
			var request = context.Request;
			var response = context.Response;

			var filePath = EngineContext.Current.Resolve<IWebHelper>().MapPath(request.Url.AbsolutePath);

			if (!File.Exists(filePath))
				return;

			var fileContents = File.ReadAllText(filePath);

			var parsedContents = LessTransform.Transform(fileContents);

			response.ContentType = "text/css";
			response.Write(parsedContents);
			response.End();
		}

		public bool IsReusable {
			get { return false; }
		}
	}
}