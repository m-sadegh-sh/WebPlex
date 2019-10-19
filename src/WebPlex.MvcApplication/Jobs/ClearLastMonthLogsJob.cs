namespace WebPlex.MvcApplication.Jobs {
	using System;

	using Quartz;

	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;

	public sealed class ClearLastMonthLogsJob : IJob {
		public const string Identity = "CLEAR_LAST_MONTH_LOGS";

		public void Execute(IJobExecutionContext context) {
			EngineContext.Current.Resolve<ILogService>().DeleteAll(l => l.LogDateUtc <= DateTime.Now.AddMonths(-1), false);
		}
	}
}