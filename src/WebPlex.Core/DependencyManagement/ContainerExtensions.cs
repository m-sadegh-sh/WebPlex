namespace WebPlex.Core.DependencyManagement {
	using System;

	using Autofac;

	public static class ContainerExtensions {
		public static void Update(this IContainer container, Action<ContainerBuilder> action) {
			var builder = new ContainerBuilder();

			action.Invoke(builder);

			builder.Update(container);
		}
	}
}