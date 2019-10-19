namespace WebPlex.Core.Domain.Entities.Security {
	using Iesi.Collections.Generic;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Core.Builders;

	public class DefaultPermissionGroup {
		private ISet<PermissionGroupEntity> _groups;

		public DefaultPermissionGroup(Constant role, PermissionGroupEntity[] groups) {
			Role = role;
			groups.ForEach(pg => Groups.Add(pg));
		}

		public Constant Role { get; private set; }

		public ISet<PermissionGroupEntity> Groups {
			get { return _groups ?? (_groups = new HashedSet<PermissionGroupEntity>()); }
		}
	}
}