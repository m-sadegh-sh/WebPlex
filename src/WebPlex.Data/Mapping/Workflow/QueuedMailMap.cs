namespace WebPlex.Data.Mapping.Workflow {
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class QueuedMailMap : EntityMapBase<QueuedMailEntity> {
		public QueuedMailMap() {
			Property(qm => qm.FromEmail);
			Property(qm => qm.FromName);
			Property(qm => qm.ToEmail);
			Property(qm => qm.ToName);
			Property(qm => qm.Cc, pm => pm.Type<CsvFormattedType<string>>());
			Property(qm => qm.Bcc, pm => pm.Type<CsvFormattedType<string>>());
			Property(qm => qm.Subject);
			Property(qm => qm.Body);
			Property(qm => qm.Importance);
			Property(qm => qm.SendTries);
			Property(qm => qm.SentDateUtc);
		}
	}
}