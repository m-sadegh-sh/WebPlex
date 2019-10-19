namespace WebPlex.Core.Engine {
	using System;
	using System.Collections.Generic;
	using System.Web.Mvc;

	using Autofac;
	using Autofac.Core;

	using CuttingEdge.Conditions;

	using WebPlex.Core.Configuration;
	using WebPlex.Core.DependencyManagement;

	public sealed class PlexEngine : IEngine {
		public PlexEngine(ContainerConfigurer configurer, PlexConfig config) {
			Condition.Requires(configurer).IsNotNull();
			Condition.Requires(config).IsNotNull();

			var container = new ContainerBuilder().Build();

			configurer.Configure(this, container, config);

			DependencyResolver.SetResolver(new PlexDependencyResolver(container));
		}

		public object Resolve(Type type, params Parameter[] parameters) {
			return PlexDependencyResolver.Current.GetService(type, parameters);
		}

		public TService Resolve<TService>(params Parameter[] parameters) where TService : class {
			return PlexDependencyResolver.Current.GetService<TService>(parameters);
		}

		public TService ResolveKeyed<TService>(string key, params Parameter[] parameters) where TService : class {
			return PlexDependencyResolver.Current.GetKeyedService<TService>(key, parameters);
		}

		public IEnumerable<object> ResolveAll(Type type) {
			return PlexDependencyResolver.Current.GetServices(type);
		}

		public IEnumerable<TService> ResolveAll<TService>() {
			return PlexDependencyResolver.Current.GetServices<TService>();
		}
	}
}