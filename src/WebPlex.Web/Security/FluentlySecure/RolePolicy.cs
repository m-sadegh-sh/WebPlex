namespace WebPlex.Web.Security.FluentlySecure {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class RolePolicy : PolicyBase {
		private readonly IAuthorizationService _authorizationService;
		private readonly RoleEntity[] _authorizedRoles;

		public RolePolicy(IAuthorizationService authorizationService, params RoleEntity[] authorizedRoles) {
			_authorizationService = authorizationService;
			_authorizedRoles = authorizedRoles;
		}

		protected override bool IsAuthorized() {
			foreach (var role in _authorizedRoles)
				return _authorizationService.IsInRole(role);

			return false;
		}
	}
}