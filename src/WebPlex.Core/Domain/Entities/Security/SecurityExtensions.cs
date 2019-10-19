namespace WebPlex.Core.Domain.Entities.Security {
	public static class SecurityExtensions {
		public static bool IsValid(this UserEntity user) {
			return user != null && user.IsEnabled && user.Membership.IsConfirmed;
		}
	}
}