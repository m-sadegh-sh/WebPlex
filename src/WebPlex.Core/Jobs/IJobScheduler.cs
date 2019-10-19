namespace WebPlex.Core.Jobs {
	using Quartz;

	public interface IJobScheduler {
		void Schedule(IScheduler scheduler);
	}
}