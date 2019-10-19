namespace WebPlex.Services.Impl.Workflow {
	using System;
	using System.Collections.Generic;

	using Iesi.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Services.Infrastructure;

	public sealed class QueuedMailService : DbServiceBase<QueuedMailEntity>, IQueuedMailService {
		public QueuedMailService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public IList<QueuedMailEntity> GetAllUnderQueues() {
			return GetAll(qm => qm.SendTries < 3 && qm.SentDateUtc == null, qm => qm.Importance, false, false);
		}

		public OperationResult<QueuedMailEntity> Save(string fromEmail,
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
				DateTime? sentDateUtc) {
			var result = EngineContext.Current.Resolve<OperationResult<QueuedMailEntity>>();

			var queuedMail = new QueuedMailEntity {
					IsEnabled = true,
					FromEmail = fromEmail,
					ToEmail = toEmail,
					FromName = fromName,
					ToName = toName,
					Cc = new HashedSet<string>(cc),
					Bcc = new HashedSet<string>(bcc),
					Subject = subject,
					Body = body,
					IsBodyHtml = isBodyHtml,
					Importance = importance,
					SendTries = sendTries,
					SentDateUtc = sentDateUtc
			};

			result += Save(queuedMail, false);

			return result.With(queuedMail);
		}

		public OperationResult InvalidateState(QueuedMailEntity queuedMail, bool succeeded) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			queuedMail.SendTries++;
			queuedMail.SentDateUtc = succeeded ? DateTime.UtcNow : (DateTime?) null;

			result += Save(queuedMail, false);

			return result;
		}
	}
}