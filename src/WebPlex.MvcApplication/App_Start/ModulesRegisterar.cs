using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PreApplicationStartMethod(typeof (ModulesRegisterar), "RegisterModules")]

namespace WebPlex.MvcApplication.App_Start {
	using System;
	using System.Web.Mvc;

	using FixFarsiCharsModule;

	using Microsoft.Web.Infrastructure.DynamicModuleHelper;

	using ProceXSS;

	using WebPlex.Web.Modules;

	using AuthorizeAttribute = WebPlex.Web.Mvc.AuthorizeAttribute;

	public class ModulesRegisterar {
		public static void RegisterModules() {
			AuthorizeAttribute.RedirectResult = new Lazy<ActionResult>(() => T4Routes.Authenticate.SignIn());
			DynamicModuleUtility.RegisterModule(typeof (AntiXSSModule));
			DynamicModuleUtility.RegisterModule(typeof (HeaderCleanerModule));
			DynamicModuleUtility.RegisterModule(typeof (UrlNormalizerModule));
			DynamicModuleUtility.RegisterModule(typeof (FixFarsiCharsModule));
			//DynamicModuleUtility.RegisterModule(typeof (CompressorModule));
			//ErrorHandlingModule.RedirectionResult = new Lazy<Func<HttpException, ActionResult>>(() => httpException => T4Routes.Error.Index(null, httpException));
			//DynamicModuleUtility.RegisterModule(typeof (ErrorHandlingModule));
			//AppClosedModule.NonRestrictedResult = new Lazy<ActionResult>(() => T4Routes.Authenticate.SignIn());
			//DynamicModuleUtility.RegisterModule(typeof (AppClosedModule));
			//DynamicModuleUtility.RegisterModule(typeof (CheckForBannedIpsModule));
		}
	}
}