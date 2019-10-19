namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class LogMap : EntityMapBase<LogEntity> {
		public LogMap() {
			Property(l => l.Severity);
			Property(l => l.LogDateUtc);
			Property(l => l.FullMessage);
			Property(l => l.StackTrace);
			Property(l => l.RequestUrl);
			Property(l => l.ReferrerUrl);
			ManyToOne(l => l.Invoker);
			Property(l => l.InvokerIp);
		}
	}
}