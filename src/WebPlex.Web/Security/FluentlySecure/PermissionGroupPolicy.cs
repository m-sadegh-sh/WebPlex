namespace WebPlex.Web.Security.FluentlySecure {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class PermissionGroupPolicy : PolicyBase {
		private readonly IAuthorizationService _authorizationService;
		private readonly PermissionGroupEntity[] _authorizedGroups;

		public PermissionGroupPolicy(IAuthorizationService authorizationService, params PermissionGroupEntity[] authorizedGroups) {
			_authorizationService = authorizationService;
			_authorizedGroups = authorizedGroups;
		}

		protected override bool IsAuthorized() {
			foreach (var group in _authorizedGroups)
				return _authorizationService.IsInGroup(group);

			return false;
		}
	}
}