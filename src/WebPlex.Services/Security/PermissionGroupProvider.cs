namespace WebPlex.Services.Security {
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.Knowns.Security;

	public sealed class PermissionGroupProvider : IPermissionGroupProvider {
		public static readonly PermissionGroupEntity Website = new PermissionGroupEntity {
				IsEnabled = true,
				Name = "وب سایت",
				InternalKey = Groups.Website
		};

		public static readonly PermissionGroupEntity Administration = new PermissionGroupEntity {
				IsEnabled = true,
				Name = "بخش مدیریت",
				InternalKey = Groups.Administration
		};

		public IEnumerable<PermissionGroupEntity> GetAll() {
			return new[] {Website, Administration};
		}

		public IEnumerable<DefaultPermissionGroup> GetDefaults() {
			return new[] {new DefaultPermissionGroup(Roles.Users, new[] {Website}), new DefaultPermissionGroup(Roles.Administrators, new[] {Administration})};
		}
	}
}