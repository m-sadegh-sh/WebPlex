namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using Iesi.Collections.Generic;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	public class RoleEntity : EntityBase {
		private ISet<PermissionGroupEntity> _groups;
		private ISet<PermissionEntity> _permissions;
		private ISet<UserEntity> _users;

		public virtual string Name { get; set; }
		public virtual Constant InternalKey { get; set; }

		public virtual ISet<PermissionGroupEntity> Groups {
			get { return _groups ?? (_groups = new HashedSet<PermissionGroupEntity>()); }
			protected set { _groups = value; }
		}

		public virtual ISet<PermissionEntity> Permissions {
			get { return _permissions ?? (_permissions = new HashedSet<PermissionEntity>()); }
			protected set { _permissions = value; }
		}

		public virtual ISet<UserEntity> Users {
			get { return _users ?? (_users = new HashedSet<UserEntity>()); }
			protected set { _users = value; }
		}

		public override string ToString() {
			return string.Format("{0} ({1})", Name, InternalKey);
		}

		public override bool Equals(object obj) {
			return Equals(obj as RoleEntity);
		}

		public virtual bool Equals(RoleEntity other) {
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