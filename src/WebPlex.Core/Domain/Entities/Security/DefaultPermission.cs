namespace WebPlex.Core.Domain.Entities.Security {
	using System.Collections.Generic;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Core.Builders;

	public class DefaultPermission {
		private ISet<PermissionEntity> _permissions;

		public DefaultPermission(Constant role, PermissionEntity[] permissions) {
			Role = role;
			permissions.ForEach(p => Permissions.Add(p));
		}

		public Constant Role { get; private set; }

		public ISet<PermissionEntity> Permissions {
			get { return _permissions ?? (_permissions = new HashSet<PermissionEntity>()); }
		}
	}
}