using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PreApplicationStartMethod(typeof (NHibernateProfilerBootstrapper), "PreStart")]

namespace WebPlex.MvcApplication.App_Start {
	using HibernatingRhinos.Profiler.Appender.NHibernate;

	public static class NHibernateProfilerBootstrapper {
		public static void PreStart() {
			NHibernateProfiler.Initialize();
		}
	}
}