namespace WebPlex.Web.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IAuthorizationService {
		bool IsInGroup(Constant groupKey);

		bool IsInGroup(PermissionGroupEntity group);

		bool IsInGroup(Constant groupKey, UserEntity user);

		bool IsInGroup(PermissionGroupEntity group, UserEntity user);

		OperationResult AddRoleToGroup(Constant groupKey, Constant roleKey);

		OperationResult AddRoleToGroup(PermissionGroupEntity group, RoleEntity role);

		bool IsInPermission(Constant permissionKey);

		bool IsInPermission(PermissionEntity permission);

		bool IsInPermission(Constant permissionKey, UserEntity user);

		bool IsInPermission(PermissionEntity permission, UserEntity user);

		OperationResult AddRoleToPermission(Constant permissionKey, Constant roleKey);

		OperationResult AddRoleToPermission(PermissionEntity permission, RoleEntity role);

		bool IsInRole(Constant roleKey);

		bool IsInRole(RoleEntity role);

		bool IsInRole(Constant roleKey, UserEntity user);

		bool IsInRole(RoleEntity role, UserEntity user);

		OperationResult AddRoleToUser(Constant roleKey);

		OperationResult AddRoleToUser(RoleEntity role);

		OperationResult AddRoleToUser(UserEntity user, Constant roleKey);

		OperationResult AddRoleToUser(UserEntity user, RoleEntity role);
	}
}