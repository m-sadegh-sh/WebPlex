namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using WebPlex.Core.Extensions;

	public class BannedIpEntity : EntityBase {
		public virtual string IpAdrress { get; set; }
		public virtual string Reason { get; set; }
		public virtual DateTime StartDateUtc { get; set; }
		public virtual DateTime? ExpireDateUtc { get; set; }

		public override string ToString() {
			return string.Format("{0} ({1})", IpAdrress, Reason);
		}

		public override bool Equals(object obj) {
			return Equals(obj as BannedIpEntity);
		}

		public virtual bool Equals(BannedIpEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(IpAdrress, other.IpAdrress, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return IpAdrress.NotNullOrDefault().GetHashCode();
		}
	}
}