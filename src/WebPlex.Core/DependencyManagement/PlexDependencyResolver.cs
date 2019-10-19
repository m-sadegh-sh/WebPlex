namespace WebPlex.Core.DependencyManagement {
	using System;
	using System.Web.Mvc;

	using Autofac;
	using Autofac.Core;
	using Autofac.Integration.Mvc;

	public sealed class PlexDependencyResolver : AutofacDependencyResolver {
		public PlexDependencyResolver(ILifetimeScope container) : base(container) {}

		public PlexDependencyResolver(ILifetimeScope container, Action<ContainerBuilder> configurationAction) : base(container, configurationAction) {}

		public PlexDependencyResolver(ILifetimeScope container, ILifetimeScopeProvider lifetimeScopeProvider) : base(container, lifetimeScopeProvider) {}

		public PlexDependencyResolver(ILifetimeScope container, ILifetimeScopeProvider lifetimeScopeProvider, Action<ContainerBuilder> configurationAction) : base(container, lifetimeScopeProvider, configurationAction) {}

		public new static PlexDependencyResolver Current {
			get { return (PlexDependencyResolver) DependencyResolver.Current; }
		}

		public object GetService(Type serviceType, params Parameter[] parameters) {
			return ((IComponentContext) RequestLifetimeScope).ResolveOptional(serviceType, parameters);
		}
	}
}