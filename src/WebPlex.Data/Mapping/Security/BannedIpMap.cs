namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class BannedIpMap : EntityMapBase<BannedIpEntity> {
		public BannedIpMap() {
			Property(bi => bi.IpAdrress);
			Property(bi => bi.Reason);
			Property(bi => bi.StartDateUtc);
			Property(bi => bi.ExpireDateUtc);
		}
	}
}