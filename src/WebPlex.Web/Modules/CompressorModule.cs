namespace WebPlex.Web.Modules {
	using System;
	using System.Web;
	using System.Web.Mvc;

	using Utilities.Compression.ExtensionMethods.Enums;

	using WebPlex.Web.Handlers;

	public sealed class CompressorModule : IHttpModule {
		public void Init(HttpApplication context) {
			context.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
		}

		private static void OnPreRequestHandlerExecute(object sender, EventArgs e) {
			var context = ((HttpApplication) sender).Context;
			var request = context.Request;
			var response = context.Response;

			if (!(context.Handler is MvcHandler || context.Handler is LessHandler))
				return;

			var acceptEncoding = request.Headers["Accept-Encoding"];

			if (acceptEncoding.IndexOf(CompressionType.GZip.ToString(), StringComparison.OrdinalIgnoreCase) >= 0) {
				response.Filter = new UglyStream(response.Filter, CompressionType.GZip);
				response.AppendHeader("Content-Encoding", CompressionType.GZip.ToString());
			} else if (acceptEncoding.IndexOf(CompressionType.Deflate.ToString(), StringComparison.OrdinalIgnoreCase) >= 0) {
				response.Filter = new UglyStream(response.Filter, CompressionType.Deflate);
				response.AppendHeader("Content-Encoding", CompressionType.Deflate.ToString());
			}
		}

		public void Dispose() {}
	}
}