namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	using Iesi.Collections.Generic;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Extensions;

	public class PermissionEntity : EntityBase {
		private ISet<RoleEntity> _roles;

		public virtual string Name { get; set; }
		public virtual Constant InternalKey { get; set; }

		public virtual PermissionGroupEntity Group { get; set; }

		public virtual ISet<RoleEntity> Roles {
			get { return _roles ?? (_roles = new HashedSet<RoleEntity>()); }
			protected set { _roles = value; }
		}

		public override string ToString() {
			return string.Format("{0} ({1}, {2})", Name, InternalKey, Group);
		}

		public override bool Equals(object obj) {
			return Equals(obj as PermissionEntity);
		}

		public virtual bool Equals(PermissionEntity other) {
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