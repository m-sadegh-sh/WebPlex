namespace WebPlex.Core.DependencyManagement {
	using System.Collections.Generic;

	using Autofac;
	using Autofac.Core;

	public static class PlexDependencyResolverExtensions {
		public static TService GetService<TService>(this PlexDependencyResolver resolver, params Parameter[] parameters) where TService : class {
			return resolver.RequestLifetimeScope.ResolveOptional<TService>(parameters);
		}

		public static TService GetKeyedService<TService>(this PlexDependencyResolver resolver, string key, params Parameter[] parameters) where TService : class {
			return resolver.RequestLifetimeScope.ResolveOptionalKeyed<TService>(parameters);
		}

		public static IEnumerable<TService> GetServices<TService>(this PlexDependencyResolver resolver) {
			return resolver.RequestLifetimeScope.ResolveOptional<IEnumerable<TService>>();
		}
	}
}