namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using Iesi.Collections.Generic;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	public class PermissionGroupEntity : EntityBase {
		private ISet<PermissionEntity> _permissions;
		private ISet<RoleEntity> _roles;

		public virtual string Name { get; set; }
		public virtual Constant InternalKey { get; set; }

		public virtual ISet<PermissionEntity> Permissions {
			get { return _permissions ?? (_permissions = new HashedSet<PermissionEntity>()); }
			protected set { _permissions = value; }
		}

		public virtual ISet<RoleEntity> Roles {
			get { return _roles ?? (_roles = new HashedSet<RoleEntity>()); }
			protected set { _roles = value; }
		}

		public override string ToString() {
			return string.Format("{0} ({1})", Name, InternalKey);
		}

		public override bool Equals(object obj) {
			return Equals(obj as PermissionGroupEntity);
		}

		public virtual bool Equals(PermissionGroupEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return Name.NotNullOrDefault().GetHashCode();
		}
	}
}