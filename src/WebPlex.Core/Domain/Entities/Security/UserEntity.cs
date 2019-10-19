namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using Iesi.Collections.Generic;

	using WebPlex.Core.Extensions;

	public class UserEntity : EntityBase {
		private ISet<RoleEntity> _roles;
		private ISet<OAuthEntity> _oAuths;

		public virtual string Email { get; set; }
		public virtual MembershipEntity Membership { get; set; }

		public virtual ISet<OAuthEntity> OAuths {
			get { return _oAuths ?? (_oAuths = new HashedSet<OAuthEntity>()); }
			protected set { _oAuths = value; }
		}

		public virtual ISet<RoleEntity> Roles {
			get { return _roles ?? (_roles = new HashedSet<RoleEntity>()); }
			protected set { _roles = value; }
		}

		public override string ToString() {
			return string.Format("{0}", Email);
		}

		public override bool Equals(object obj) {
			return Equals(obj as UserEntity);
		}

		public virtual bool Equals(UserEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Email, other.Email, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return Email.NotNullOrDefault().GetHashCode();
		}
	}
}