namespace WebPlex.MvcApplication.Jobs.Schedulers {
	using Quartz;

	using WebPlex.Core.Jobs;

	public sealed class ClearLastMonthLogsScheduler : IJobScheduler {
		public void Schedule(IScheduler scheduler) {
			var details = JobBuilder.Create<ClearLastMonthLogsJob>().WithIdentity(ClearLastMonthLogsJob.Identity).Build();

			var trigger = TriggerBuilder.Create().WithIdentity(ClearLastMonthLogsJob.Identity).WithSimpleSchedule(ssb => ssb.WithIntervalInHours(12).RepeatForever()).Build();

			scheduler.ScheduleJob(details, trigger);
		}
	}
}