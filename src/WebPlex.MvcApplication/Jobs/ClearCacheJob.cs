namespace WebPlex.MvcApplication.Jobs {
	using Quartz;

	using WebPlex.Core.Caching;
	using WebPlex.Core.Engine;

	public sealed class ClearCacheJob : IJob {
		public const string Identity = "CLEAR_CACHE";

		public void Execute(IJobExecutionContext context) {
			EngineContext.Current.Resolve<ICacheManager>().Clear();
		}
	}
}