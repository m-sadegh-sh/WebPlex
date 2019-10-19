namespace WebPlex.Services.Impl.Workflow {
	using System;
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Services.Infrastructure;

	public interface IQueuedMailService : IDbService<QueuedMailEntity> {
		IList<QueuedMailEntity> GetAllUnderQueues();

		OperationResult<QueuedMailEntity> Save(string fromEmail,
				string fromName,
				string toEmail,
				string toName,
				ICollection<string> cc,
				ICollection<string> bcc,
				string subject,
				string body,
				bool isBodyHtml,
				QueuedMailImportance importance,
				int sendTries,
				DateTime? sentDateUtc);

		OperationResult InvalidateState(QueuedMailEntity queuedMail, bool succeeded);
	}
}