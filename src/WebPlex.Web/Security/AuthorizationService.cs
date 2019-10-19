namespace WebPlex.Web.Security {
	using System.Linq;

	using WebPlex.Core;
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class AuthorizationService : IAuthorizationService {
		private readonly IPermissionGroupService _groupService;
		private readonly IPermissionService _permissionService;
		private readonly IRoleService _roleService;
		private readonly IUserService _userService;
		private readonly IWorkContext _workContext;

		public AuthorizationService(IPermissionGroupService groupService, IPermissionService permissionService, IRoleService roleService, IUserService userService, IWorkContext workContext) {
			_groupService = groupService;
			_permissionService = permissionService;
			_roleService = roleService;
			_userService = userService;
			_workContext = workContext;
		}

		public bool IsInGroup(Constant groupKey) {
			var group = _groupService.Get(groupKey, false, true);

			return IsInGroup(group);
		}

		public bool IsInGroup(PermissionGroupEntity group) {
			var user = _workContext.CurrentUser;

			return IsInGroup(group, user);
		}

		public bool IsInGroup(Constant groupKey, UserEntity user) {
			var group = _groupService.Get(groupKey, false, true);

			return IsInGroup(group, user);
		}

		public bool IsInGroup(PermissionGroupEntity group, UserEntity user) {
			if (group == null)
				return false;

			if (user == null)
				return false;

			var roles = user.Roles.Where(r => r.IsEnabled);

			var isAuthorized = roles.Any(r => r.Groups.Any(pg => pg.IsEnabled && pg.InternalKey == group.InternalKey));

			return isAuthorized;
		}

		public OperationResult AddRoleToGroup(Constant groupKey, Constant roleKey) {
			var group = _groupService.Get(groupKey, false, true);
			var role = _roleService.Get(roleKey, false, true);

			return AddRoleToGroup(group, role);
		}

		public OperationResult AddRoleToGroup(PermissionGroupEntity group, RoleEntity role) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			if (group == null)
				return result.AddError(Messages.Authorization_InvalidGroup);

			if (role == null)
				return result.AddError(Messages.Authorization_InvalidRole);

			if (@group.Roles.All(r => r != role)) {
				group.Roles.Add(role);
				result += _groupService.Save(group, false);
			}

			return result;
		}

		public bool IsInPermission(Constant permissionKey) {
			var permission = _permissionService.Get(permissionKey, false, true);

			return IsInPermission(permission);
		}

		public bool IsInPermission(PermissionEntity permission) {
			var user = _workContext.CurrentUser;

			return IsInPermission(permission, user);
		}

		public bool IsInPermission(Constant permissionKey, UserEntity user) {
			var permission = _permissionService.Get(permissionKey, false, true);

			return IsInPermission(permission, user);
		}

		public bool IsInPermission(PermissionEntity permission, UserEntity user) {
			if (permission == null)
				return false;

			if (user == null)
				return false;

			var roles = user.Roles.Where(r => r.IsEnabled);

			var isAuthorized = roles.Any(r => r.Permissions.Any(pg => pg.IsEnabled && pg.InternalKey == permission.InternalKey));

			return isAuthorized;
		}

		public OperationResult AddRoleToPermission(Constant permissionKey, Constant roleKey) {
			var permission = _permissionService.Get(permissionKey, false, true);
			var role = _roleService.Get(roleKey, false, true);

			return AddRoleToPermission(permission, role);
		}

		public OperationResult AddRoleToPermission(PermissionEntity permission, RoleEntity role) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			if (permission == null)
				return result.AddError(Messages.Authorization_InvalidPermission);

			if (role == null)
				return result.AddError(Messages.Authorization_InvalidRole);

			if (permission.Roles.All(r => r != role)) {
				permission.Roles.Add(role);
				result += _permissionService.Save(permission, false);
			}

			return result;
		}

		public bool IsInRole(Constant roleKey) {
			var role = _roleService.Get(roleKey, false, true);

			return IsInRole(role);
		}

		public bool IsInRole(RoleEntity role) {
			var user = _workContext.CurrentUser;

			return IsInRole(role, user);
		}

		public bool IsInRole(Constant roleKey, UserEntity user) {
			var role = _roleService.Get(roleKey, false, true);

			return IsInRole(role, user);
		}

		public bool IsInRole(RoleEntity role, UserEntity user) {
			if (role == null)
				return false;

			if (user == null)
				return false;

			var roles = user.Roles.Where(r => r.IsEnabled);

			var isAuthorized = roles.Any(r => r.InternalKey == role.InternalKey);

			return isAuthorized;
		}

		public OperationResult AddRoleToUser(Constant roleKey) {
			var role = _roleService.Get(roleKey, false, true);

			return AddRoleToUser(role);
		}

		public OperationResult AddRoleToUser(RoleEntity role) {
			var user = _workContext.CurrentUser;

			return AddRoleToUser(user, role);
		}

		public OperationResult AddRoleToUser(UserEntity user, Constant roleKey) {
			var role = _roleService.Get(roleKey, false, true);

			return AddRoleToUser(user, role);
		}

		public OperationResult AddRoleToUser(UserEntity user, RoleEntity role) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			if (user == null)
				return result.AddError(Messages.Authorization_InvalidUser);

			if (role == null)
				return result.AddError(Messages.Authorization_InvalidRole);

			if (user.Roles.All(r => r != role)) {
				user.Roles.Add(role);
				result += _userService.Save(user, false);
			}

			return result;
		}
	}
}