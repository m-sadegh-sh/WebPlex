namespace WebPlex.Web.Security.FluentlySecure {
	using Autofac;

	using FluentSecurity.Configuration;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;

	public static class PolicyContainerExtensions {
		public static IPolicyContainerConfiguration GroupPolicy(this IPolicyContainerConfiguration policyContainer, params PermissionGroupEntity[] groups) {
			return policyContainer.AddPolicy(EngineContext.Current.Resolve<PermissionGroupPolicy>(new PositionalParameter(1, groups)));
		}

		public static IPolicyContainerConfiguration PermissionPolicy(this IPolicyContainerConfiguration policyContainer, params PermissionEntity[] permissions) {
			return policyContainer.AddPolicy(EngineContext.Current.Resolve<PermissionPolicy>(new PositionalParameter(1, permissions)));
		}

		public static IPolicyContainerConfiguration RolePolicy(this IPolicyContainerConfiguration policyContainer, params RoleEntity[] roles) {
			return policyContainer.AddPolicy(EngineContext.Current.Resolve<RolePolicy>(new PositionalParameter(1, roles)));
		}
	}
}