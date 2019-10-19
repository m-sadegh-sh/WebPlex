namespace WebPlex.Data.Mapping.Contents {
	using WebPlex.Core.Domain.Entities.Contents;

	public sealed class SubscriptionMap : EntityMapBase<SubscriptionEntity> {
		public SubscriptionMap() {
			Property(s => s.Email);
			Property(s => s.Status);
			Property(s => s.SubscribDateUtc);
			Property(s => s.ConfirmDateUtc);
			Property(s => s.CancelDateUtc);
		}
	}
}