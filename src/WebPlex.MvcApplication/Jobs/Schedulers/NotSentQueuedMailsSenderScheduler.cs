namespace WebPlex.MvcApplication.Jobs.Schedulers {
	using Quartz;

	using WebPlex.Core.Jobs;

	public sealed class NotSentQueuedMailsSenderScheduler : IJobScheduler {
		public void Schedule(IScheduler scheduler) {
			var details = JobBuilder.Create<NotSentQueuedMailsSenderJob>().WithIdentity(NotSentQueuedMailsSenderJob.Identity).Build();

			var trigger = TriggerBuilder.Create().WithIdentity(NotSentQueuedMailsSenderJob.Identity).WithSimpleSchedule(ssb => ssb.WithIntervalInMinutes(5).RepeatForever()).Build();

			scheduler.ScheduleJob(details, trigger);
		}
	}
}