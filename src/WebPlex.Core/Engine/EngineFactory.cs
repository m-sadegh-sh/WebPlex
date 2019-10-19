namespace WebPlex.Core.Engine {
	using WebPlex.Core.Configuration;
	using WebPlex.Core.DependencyManagement;

	public static class EngineFactory {
		public static IEngine Create() {
			var config = PlexConfig.Current;

			return new PlexEngine(new ContainerConfigurer(), config);
		}
	}
}