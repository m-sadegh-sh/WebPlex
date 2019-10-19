using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (ClientValidationExtensionsRegistrar), "RegisterExstensions")]

namespace WebPlex.MvcApplication.App_Start {
	using DataAnnotationsExtensions.ClientValidation;

	public static class ClientValidationExtensionsRegistrar {
		public static void RegisterExstensions() {
			DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();
		}
	}
}