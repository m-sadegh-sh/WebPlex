using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (OAuthConfigurer), "RegisterProviders")]

namespace WebPlex.MvcApplication.App_Start {
	using Microsoft.Web.WebPages.OAuth;

	using WebPlex.Resources;
	using WebPlex.Web.Security;

	public static class OAuthConfigurer {
		public static void RegisterProviders() {
			var oauthConfig = OAuthConfig.Current;

			if (oauthConfig.MicrosoftEnabled)
				OAuthWebSecurity.RegisterMicrosoftClient(oauthConfig.MicrosoftClientId, oauthConfig.MicrosoftClientSecret, Views.Literal_OAuth_Microsoft);

			if (oauthConfig.LinkedInEnabled)
				OAuthWebSecurity.RegisterLinkedInClient(oauthConfig.LinkedInConsumerKey, oauthConfig.LinkedInConsumerSecret, Views.Literal_OAuth_LinkedIn);

			if (oauthConfig.TwitterEnabled)
				OAuthWebSecurity.RegisterTwitterClient(oauthConfig.TwitterConsumerKey, oauthConfig.TwitterConsumerSecret, Views.Literal_OAuth_Twitter);

			if (oauthConfig.FacebookEnabled)
				OAuthWebSecurity.RegisterFacebookClient(oauthConfig.FacebookAppId, oauthConfig.FacebookAppSecret, Views.Literal_OAuth_Facebook);

			if (oauthConfig.GoogleEnabled)
				OAuthWebSecurity.RegisterGoogleClient(Views.Literal_OAuth_Google);

			if (oauthConfig.YahooEnabled)
				OAuthWebSecurity.RegisterYahooClient(Views.Literal_OAuth_Yahoo);
		}
	}
}