namespace WebPlex.Core.DependencyManagement {
	using System.Collections.Generic;
	using System.Linq;

	using Autofac;
	using Autofac.Core;

	using Utilities.DataTypes.ExtensionMethods;

	using WebPlex.Core.Configuration;
	using WebPlex.Core.DependencyManagement.TypeFinders;
	using WebPlex.Core.Engine;

	public sealed class ContainerConfigurer {
		public void Configure(IEngine engine, IContainer container, PlexConfig config) {
			container.Update(cb => cb.RegisterInstance(engine));
			container.Update(cb => cb.RegisterInstance(config));

			container.Update(cb => cb.RegisterType<WebAppTypeFinder>().As<ITypeFinder>());

			var typeFinder = container.Resolve<ITypeFinder>();
			var assemblies = typeFinder.GetAssemblies().ToArray();

			container.Update(cb => cb.RegisterAssemblyTypes(assemblies).Where(t => t.IsAssignableTo<IModule>()).AsImplementedInterfaces());

			var modules = container.Resolve<IEnumerable<IModule>>();

			container.Update(cb => modules.ForEach(cb.RegisterModule));
		}
	}
}