namespace WebPlex.Web.Security.FluentlySecure {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class PermissionPolicy : PolicyBase {
		private readonly IAuthorizationService _authorizationService;
		private readonly PermissionEntity[] _authorizedPermissions;

		public PermissionPolicy(IAuthorizationService authorizationService, params PermissionEntity[] authorizedPermissions) {
			_authorizationService = authorizationService;
			_authorizedPermissions = authorizedPermissions;
		}

		protected override bool IsAuthorized() {
			foreach (var permission in _authorizedPermissions)
				return _authorizationService.IsInPermission(permission);

			return false;
		}
	}
}