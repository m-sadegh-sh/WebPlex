namespace WebPlex.MvcApplication {
	using System.Linq;

	using Autofac;
	using Autofac.Integration.Mvc;

	using MarkdownSharp;

	using Quartz;
	using Quartz.Impl;

	using WebPlex.Core.DependencyManagement.TypeFinders;

	public sealed class MvcApplicationTypesModule : Module {
		private readonly ITypeFinder _typeFinder;

		public MvcApplicationTypesModule(ITypeFinder typeFinder) {
			_typeFinder = typeFinder;
		}

		protected override void Load(ContainerBuilder builder) {
			builder.RegisterControllers(_typeFinder.GetAssemblies().ToArray());

			builder.RegisterType<Markdown>().SingleInstance();

			builder.RegisterType<StdSchedulerFactory>().As<ISchedulerFactory>().SingleInstance();
			builder.Register(cc => cc.Resolve<ISchedulerFactory>().GetScheduler()).SingleInstance();
		}
	}
}