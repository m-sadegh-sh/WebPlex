using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (JobRunner), "StartJobs")]

namespace WebPlex.MvcApplication.App_Start {
	using System;
	using System.Linq;

	using Quartz;

	using WebPlex.Core.DependencyManagement.TypeFinders;
	using WebPlex.Core.Engine;
	using WebPlex.Core.Jobs;

	public static class JobRunner {
		public static void StartJobs() {
			var scheduler = EngineContext.Current.Resolve<IScheduler>();

			var typeFinder = EngineContext.Current.Resolve<ITypeFinder>();

			var jobSchedulers = (from types in typeFinder.FindClassesOfType<IJobScheduler>()
				let jobScheduler = (IJobScheduler) Activator.CreateInstance(types)
				select jobScheduler).ToList();

			foreach (var jobScheduler in jobSchedulers)
				jobScheduler.Schedule(scheduler);

			scheduler.Start();
		}
	}
}