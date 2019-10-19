namespace WebPlex.Web.Security.FluentlySecure {
	using FluentSecurity;
	using FluentSecurity.Policy;

	public abstract class PolicyBase : ISecurityPolicy {
		public PolicyResult Enforce(ISecurityContext context) {
			if (IsAuthorized())
				return PolicyResult.CreateSuccessResult(this);

			return PolicyResult.CreateFailureResult(this, "Access denied.");
		}

		protected abstract bool IsAuthorized();
	}
}