namespace WebPlex.MvcApplication.Jobs {
	using Quartz;

	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Contents;

	public sealed class NotConfirmedSubscriptionsRemoverJob : IJob {
		public const string Identity = "NOT_CONFIRMED_SUBSCRIPTIONS_REMOVER";

		public void Execute(IJobExecutionContext context) {
			var subscriptionService = EngineContext.Current.Resolve<ISubscriptionService>();

			var subscriptions = subscriptionService.GetAllConfirmationExpired();

			subscriptionService.DeleteAll(subscriptions, false);
		}
	}
}