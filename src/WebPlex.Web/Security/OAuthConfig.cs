namespace WebPlex.Web.Security {
	using System.Xml;

	using WebPlex.Core.Configuration;

	public sealed class OAuthConfig : ConfigBase<OAuthConfig> {
		private static OAuthConfig _current;

		public static OAuthConfig Current {
			get {
				if (_current == null)
					_current = Load<OAuthConfig>();

				return _current;
			}
		}

		public bool MicrosoftEnabled { get; private set; }
		public string MicrosoftClientId { get; private set; }
		public string MicrosoftClientSecret { get; private set; }

		public bool LinkedInEnabled { get; private set; }
		public string LinkedInConsumerKey { get; private set; }
		public string LinkedInConsumerSecret { get; private set; }

		public bool TwitterEnabled { get; private set; }
		public string TwitterConsumerKey { get; private set; }
		public string TwitterConsumerSecret { get; private set; }

		public bool FacebookEnabled { get; private set; }
		public string FacebookAppId { get; private set; }
		public string FacebookAppSecret { get; private set; }

		public bool GoogleEnabled { get; private set; }

		public bool YahooEnabled { get; private set; }

		public override object Create(object parent, object configContext, XmlNode section) {
			var config = new OAuthConfig {
					MicrosoftEnabled = GetAttribute(section, oac => oac.MicrosoftEnabled),
					MicrosoftClientId = GetAttribute(section, oac => oac.MicrosoftClientId),
					MicrosoftClientSecret = GetAttribute(section, oac => oac.MicrosoftClientSecret),
					LinkedInEnabled = GetAttribute(section, oac => oac.LinkedInEnabled),
					LinkedInConsumerKey = GetAttribute(section, oac => oac.LinkedInConsumerKey),
					LinkedInConsumerSecret = GetAttribute(section, oac => oac.LinkedInConsumerSecret),
					TwitterEnabled = GetAttribute(section, oac => oac.TwitterEnabled),
					TwitterConsumerKey = GetAttribute(section, oac => oac.TwitterConsumerKey),
					TwitterConsumerSecret = GetAttribute(section, oac => oac.TwitterConsumerSecret),
					FacebookEnabled = GetAttribute(section, oac => oac.FacebookEnabled),
					FacebookAppId = GetAttribute(section, oac => oac.FacebookAppId),
					FacebookAppSecret = GetAttribute(section, oac => oac.FacebookAppSecret),
					GoogleEnabled = GetAttribute(section, oac => oac.GoogleEnabled),
					YahooEnabled = GetAttribute(section, oac => oac.YahooEnabled)
			};

			return config;
		}
	}
}