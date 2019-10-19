namespace WebPlex.Core.DependencyManagement.TypeFinders {
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Web;
	using System.Web.Hosting;

	using WebPlex.Core.Configuration;

	public sealed class WebAppTypeFinder : AppDomainTypeFinder {
		private bool _binFolderAssembliesLoaded;

		public WebAppTypeFinder(PlexConfig config) {
			EnsureBinFolderAssembliesLoaded = config.DynamicDiscovery;
		}

		public bool EnsureBinFolderAssembliesLoaded { get; set; }

		public string GetBinDirectory() {
			string binDirectory;

			if (HostingEnvironment.IsHosted)
				binDirectory = HttpRuntime.BinDirectory;
			else
				binDirectory = AppDomain.CurrentDomain.BaseDirectory;

			return binDirectory;
		}

		public override IList<Assembly> GetAssemblies() {
			if (EnsureBinFolderAssembliesLoaded && !_binFolderAssembliesLoaded) {
				_binFolderAssembliesLoaded = true;
				var binPath = GetBinDirectory();

				LoadMatchingAssemblies(binPath);
			}

			var assemblies = base.GetAssemblies();

			return assemblies;
		}
	}
}