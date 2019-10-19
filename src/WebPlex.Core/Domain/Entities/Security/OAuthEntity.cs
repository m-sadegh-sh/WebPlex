namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	public class OAuthEntity : EntityBase {
		public virtual Constant ProviderKey { get; set; }
		public virtual Constant UserKey { get; set; }
		public virtual UserEntity User { get; set; }

		public override string ToString() {
			return string.Format("{0}:{1} ({2})", ProviderKey, UserKey, User);
		}

		public override bool Equals(object obj) {
			return Equals(obj as OAuthEntity);
		}

		public virtual bool Equals(OAuthEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(ProviderKey, other.ProviderKey, StringComparison.InvariantCulture) && string.Equals(UserKey, other.UserKey, StringComparison.InvariantCulture);
		}

		public override int GetHashCode() {
			return ProviderKey.ToStringOrDefault().GetHashCode() ^ UserKey.ToStringOrDefault().GetHashCode();
		}
	}
}