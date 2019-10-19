namespace WebPlex.Data.NHibernating {
	using System.IO;
	using System.Reflection;
	using System.Runtime.Serialization.Formatters.Binary;

	using NHibernate.Cfg;

	using WebPlex.Core;
	using WebPlex.Core.Configuration;

	public sealed class ConfigurationFileCache {
		private readonly string _cacheFile;
		private readonly Assembly _definitionsAssembly;

		public ConfigurationFileCache(PlexConfig config, Assembly definitionsAssembly, IWebHelper webHelper) {
			_definitionsAssembly = definitionsAssembly;
			_cacheFile = webHelper.MapPath(config.ConfigurationCacheFileName);
		}

		public void DeleteCacheFile() {
			if (File.Exists(_cacheFile))
				File.Delete(_cacheFile);
		}

		public bool IsConfigurationFileValid {
			get {
				if (!File.Exists(_cacheFile))
					return false;

				var configInfo = new FileInfo(_cacheFile);
				var asmInfo = new FileInfo(_definitionsAssembly.Location);

				if (configInfo.Length < 5*1024)
					return false;

				return configInfo.LastWriteTime >= asmInfo.LastWriteTime;
			}
		}

		public void SaveToFile(Configuration configuration) {
			using (var file = File.Open(_cacheFile, FileMode.Create))
				new BinaryFormatter().Serialize(file, configuration);
		}

		public Configuration LoadFromFile() {
			if (!IsConfigurationFileValid)
				return null;

			using (var file = File.Open(_cacheFile, FileMode.Open, FileAccess.Read))
				return new BinaryFormatter().Deserialize(file) as Configuration;
		}
	}
}