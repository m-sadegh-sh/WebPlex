namespace WebPlex.Web.Mvc {
	using System.Web.Mvc;

	using Microsoft.Web.WebPages.OAuth;

	public sealed class ExternalLoginResult : ActionResult {
		public ExternalLoginResult(string provider, string returnUrl) {
			ProviderKey = provider;
			ReturnUrl = returnUrl;
		}

		public string ProviderKey { get; private set; }
		public string ReturnUrl { get; private set; }

		public override void ExecuteResult(ControllerContext context) {
			OAuthWebSecurity.RequestAuthentication(ProviderKey, ReturnUrl);
		}
	}
}