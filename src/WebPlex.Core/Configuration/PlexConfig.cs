namespace WebPlex.Core.Configuration {
	using System.Xml;

	public sealed class PlexConfig : ConfigBase<PlexConfig> {
		private static PlexConfig _current;

		public static PlexConfig Current {
			get {
				if (_current == null)
					_current = Load<PlexConfig>();

				return _current;
			}
		}

		public bool DynamicDiscovery { get; private set; }
		public string ConnectionString { get; private set; }
		public string ConfigurationCacheFileName { get; private set; }

		public override object Create(object parent, object configContext, XmlNode section) {
			var config = new PlexConfig {
					DynamicDiscovery = GetAttribute(section, fc => fc.DynamicDiscovery),
					ConnectionString = GetAttribute(section, fc => fc.ConnectionString),
					ConfigurationCacheFileName = GetAttribute(section, fc => fc.ConfigurationCacheFileName)
			};

			return config;
		}
	}
}