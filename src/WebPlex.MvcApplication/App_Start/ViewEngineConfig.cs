using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (ViewEngineConfig), "RegisterEngines")]

namespace WebPlex.MvcApplication.App_Start {
	using System.Web.Mvc;

	public static class ViewEngineConfig {
		public static void RegisterEngines() {
			var engines = ViewEngines.Engines;

			engines.Clear();

			//var engine = new PrecompiledMvcEngine(typeof (ViewEngineConfig).Assembly) {
			//		UsePhysicalViewsIfNewer = true
			//};

			var engine = new RazorViewEngine();

			engines.Add(engine);

			//VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);
		}
	}
}