namespace WebPlex.Core.Engine {
	public sealed class EngineContext {
		public static IEngine Current {
			get {
				if (Singleton<IEngine>.Instance == null)
					Singleton<IEngine>.Instance = EngineFactory.Create();

				return Singleton<IEngine>.Instance;
			}
		}
	}
}