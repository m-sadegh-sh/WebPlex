namespace WebPlex.MvcApplication.Jobs.Schedulers {
	using Quartz;

	using WebPlex.Core.Jobs;

	public sealed class NotConfirmedSubscriptionsRemoverScheduler : IJobScheduler {
		public void Schedule(IScheduler scheduler) {
			var details = JobBuilder.Create<NotConfirmedSubscriptionsRemoverJob>().WithIdentity(NotConfirmedSubscriptionsRemoverJob.Identity).Build();

			var trigger = TriggerBuilder.Create().WithIdentity(NotConfirmedSubscriptionsRemoverJob.Identity).WithSimpleSchedule(ssb => ssb.WithIntervalInHours(1).RepeatForever()).Build();

			scheduler.ScheduleJob(details, trigger);
		}
	}
}