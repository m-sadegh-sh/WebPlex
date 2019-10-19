namespace WebPlex.Web.Modules {
	using System;
	using System.Linq;
	using System.Web;

	public sealed class UrlNormalizerModule : IHttpModule {
		public void Init(HttpApplication context) {
			context.BeginRequest += OnBeginRequest;
		}

		private static void OnBeginRequest(object sender, EventArgs e) {
			var context = ((HttpApplication) sender).Context;
			var request = context.Request;
			var response = context.Response;
			var path = request.Url.AbsolutePath;

			var isPost = string.Equals(request.HttpMethod, "POST", StringComparison.CurrentCulture);
			var hasAnyUppercase = path.Any(char.IsUpper);
			var trailingSlashNeeded = string.IsNullOrEmpty(request.CurrentExecutionFilePathExtension) && !path.EndsWith("/");

			if (isPost || !hasAnyUppercase && !trailingSlashNeeded)
				return;

			var normalizedUrl = path.ToLowerInvariant().TrimEnd('/');

			if (trailingSlashNeeded)
				normalizedUrl += "/" + request.Url.Query;

			response.RedirectPermanent(normalizedUrl);
		}

		public void Dispose() {}
	}
}