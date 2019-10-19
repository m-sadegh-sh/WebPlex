namespace WebPlex.Core.Engine {
	using System;
	using System.Collections.Generic;

	using Autofac.Core;

	public interface IEngine {
		object Resolve(Type type, params Parameter[] parameters);

		TService Resolve<TService>(params Parameter[] parameters) where TService : class;

		TService ResolveKeyed<TService>(string key, params Parameter[] parameters) where TService : class;

		IEnumerable<object> ResolveAll(Type type);
		IEnumerable<TService> ResolveAll<TService>();
	}
}