using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (FilterConfig), "RegisterGlobalFilters")]

namespace WebPlex.MvcApplication.App_Start {
	using System.Web.Mvc;

	using WebPlex.Web.Mvc;

	public class FilterConfig {
		public static void RegisterGlobalFilters() {
			var filters = GlobalFilters.Filters;

			filters.Clear();

			filters.Add(new CultureFilterAttribute());
		}
	}
}