namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	public class OAuthTokenEntity : EntityBase {
		public virtual Constant Token { get; set; }
		public virtual Constant Secret { get; set; }

		public override string ToString() {
			return string.Format("{0}: {1}", Token, Secret);
		}

		public override bool Equals(object obj) {
			return Equals(obj as OAuthTokenEntity);
		}

		public virtual bool Equals(OAuthTokenEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Token, other.Token, StringComparison.InvariantCulture) && string.Equals(Secret, other.Secret, StringComparison.InvariantCulture);
		}

		public override int GetHashCode() {
			return Token.ToStringOrDefault().GetHashCode() ^ Secret.ToStringOrDefault().GetHashCode();
		}
	}
}