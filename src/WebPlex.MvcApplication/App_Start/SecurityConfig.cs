using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (SecurityConfig), "Configure")]

namespace WebPlex.MvcApplication.App_Start {
	public static class SecurityConfig {
		public static void Configure() {
			//SecurityConfigurator.Configure(configuration => {
			//								   configuration.GetAuthenticationStatusFrom(() => EngineContext.Current.Resolve<IIdentity>().IsAuthenticated);

			//								   configuration.For<HomeController>(h => h.Index()).PermissionPolicy(PermissionProvider.Home);
			//							   });
		}
	}
}