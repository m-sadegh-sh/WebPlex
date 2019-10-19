namespace WebPlex.Services.Security {
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.Knowns.Security;

	public sealed class PermissionProvider : IPermissionProvider {
		public static readonly PermissionEntity Home = new PermissionEntity {
				IsEnabled = true,
				Name = "خانه",
				InternalKey = Permissions.Home,
				Group = PermissionGroupProvider.Website
		};

		public static readonly PermissionEntity Dashboard = new PermissionEntity {
				IsEnabled = true,
				Name = "داشبورد",
				InternalKey = Permissions.Dashboard,
				Group = PermissionGroupProvider.Administration
		};

		public IEnumerable<PermissionEntity> GetAll() {
			return new[] {Home, Dashboard};
		}

		public IEnumerable<DefaultPermission> GetDefaults() {
			return new[] {new DefaultPermission(Roles.Users, new[] {Home}), new DefaultPermission(Roles.Administrators, new[] {Dashboard})};
		}
	}
}