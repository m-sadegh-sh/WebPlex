namespace WebPlex.Web.Modules {
	using System;
	using System.Net;
	using System.Web;

	using WebPlex.Core;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;

	public sealed class CheckForBannedIpsModule : IHttpModule {
		public void Init(HttpApplication context) {
			context.AuthenticateRequest += OnAuthenticateRequest;
		}

		private static void OnAuthenticateRequest(object sender, EventArgs e) {
			var bannedIpService = EngineContext.Current.Resolve<IBannedIpService>();
			var webHelper = EngineContext.Current.Resolve<IWebHelper>();

			var currentIp = webHelper.GetIpAddress();
			var isBanned = bannedIpService.IsBanned(currentIp);

			if (isBanned)
				throw new HttpException((int) HttpStatusCode.Forbidden, null);
		}

		public void Dispose() {}
	}
}