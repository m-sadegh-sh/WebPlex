namespace WebPlex.Web.Modules {
	using System;
	using System.Web;
	using System.Web.Mvc;

	using WebPlex.Core;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Web.Mvc;

	public sealed class ErrorHandlingModule : IHttpModule {
		public static Lazy<Func<HttpException, ActionResult>> RedirectionResult { private get; set; }

		public void Init(HttpApplication context) {
			context.Error += OnError;
		}

		private static void OnError(object sender, EventArgs e) {
			var application = (HttpApplication) sender;
			var context = application.Context;
			var server = application.Server;

			var exception = server.GetLastError();
			if (exception == null)
				return;

			var logService = EngineContext.Current.Resolve<ILogService>();
			var workContext = EngineContext.Current.Resolve<IWorkContext>();

			logService.Error(exception.Message, exception, workContext.CurrentUser);

			var httpException = exception as HttpException ?? new HttpException(null, exception);

			var result = RedirectionResult.Value(httpException);

			server.ClearError();
			context.ExecuteAction(result);
		}

		public void Dispose() {}
	}
}