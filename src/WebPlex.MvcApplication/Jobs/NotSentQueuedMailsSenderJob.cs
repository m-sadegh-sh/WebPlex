namespace WebPlex.MvcApplication.Jobs {
	using Quartz;

	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Workflow;
	using WebPlex.Services.Utils;

	public sealed class NotSentQueuedMailsSenderJob : IJob {
		public const string Identity = "PENDING_QUEUEDMAILS_SENDER";

		public void Execute(IJobExecutionContext context) {
			var messageService = EngineContext.Current.Resolve<IMessageService>();
			var queuedMailService = EngineContext.Current.Resolve<IQueuedMailService>();

			var queuedMails = queuedMailService.GetAllUnderQueues();

			foreach (var queuedMail in queuedMails) {
				var succeeded = messageService.SendQueuedMail(queuedMail);

				queuedMailService.InvalidateState(queuedMail, succeeded);
			}
		}
	}
}