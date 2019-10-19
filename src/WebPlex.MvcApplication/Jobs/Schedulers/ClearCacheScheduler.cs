namespace WebPlex.MvcApplication.Jobs.Schedulers {
	using Quartz;

	using WebPlex.Core.Jobs;

	public sealed class ClearCacheScheduler : IJobScheduler {
		public void Schedule(IScheduler scheduler) {
			var details = JobBuilder.Create<ClearCacheJob>().WithIdentity(ClearCacheJob.Identity).Build();

			var trigger = TriggerBuilder.Create().WithIdentity(ClearCacheJob.Identity).WithSimpleSchedule(ssb => ssb.WithIntervalInMinutes(10).RepeatForever()).Build();

			scheduler.ScheduleJob(details, trigger);
		}
	}
}