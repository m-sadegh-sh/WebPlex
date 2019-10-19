namespace WebPlex.Services.Security {
	using System.Linq;

	using WebPlex.Services.Impl.Security;

	public sealed class PermissionInstaller {
		private readonly IPermissionGroupService _groupService;
		private readonly IPermissionGroupProvider _groupProvider;
		private readonly IPermissionService _permissionService;
		private readonly IPermissionProvider _permissionProvider;
		private readonly IRoleService _roleService;

		public PermissionInstaller(IPermissionGroupService groupService, IPermissionGroupProvider groupProvider, IPermissionService permissionService, IPermissionProvider permissionProvider, IRoleService roleService) {
			_groupService = groupService;
			_groupProvider = groupProvider;
			_permissionService = permissionService;
			_permissionProvider = permissionProvider;
			_roleService = roleService;
		}

		public void EnsureGroupsInstalled() {
			var groups = _groupProvider.GetAll();

			foreach (var group in groups) {
				_groupService.Save(group, false);

				var defaultGroups = _groupProvider.GetDefaults();

				foreach (var defaultGroup in defaultGroups) {
					var role = _roleService.Get(defaultGroup.Role, true, false);

					if (role == null)
						role = _roleService.Save(defaultGroup.Role, defaultGroup.Role).Value;

					var defaultMappingProvided = defaultGroup.Groups.Any(pg => pg.InternalKey == group.InternalKey);

					var mappingExists = role.Groups.Any(pg => pg.InternalKey == group.InternalKey);

					if (defaultMappingProvided && !mappingExists)
						group.Roles.Add(role);
				}

				_groupService.Save(group, false);
			}
		}

		public void UninstallDefaultGroups() {
			var groups = _groupProvider.GetAll();

			foreach (var group in groups)
				_groupService.Delete(group.InternalKey, false);
		}

		public void EnsurePermissionsInstalled() {
			var permissions = _permissionProvider.GetAll();

			foreach (var permission in permissions) {
				_permissionService.Save(permission, false);

				var defaultPermissions = _permissionProvider.GetDefaults();

				foreach (var defaultPermission in defaultPermissions) {
					var role = _roleService.Get(defaultPermission.Role, true, false);

					if (role == null)
						role = _roleService.Save(defaultPermission.Role, defaultPermission.Role).Value;

					var defaultMappingProvided = defaultPermission.Permissions.Any(p => p.InternalKey == permission.InternalKey);

					var mappingExists = role.Permissions.Any(p => p.InternalKey == permission.InternalKey);

					if (defaultMappingProvided && !mappingExists)
						permission.Roles.Add(role);
				}

				_permissionService.Save(permission, false);
			}
		}

		public void UninstallDefaultPermissions() {
			var permissions = _permissionProvider.GetAll();

			foreach (var permission in permissions)
				_permissionService.Delete(permission.InternalKey, false);
		}
	}
}