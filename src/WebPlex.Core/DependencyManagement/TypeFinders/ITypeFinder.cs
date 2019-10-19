namespace WebPlex.Core.DependencyManagement.TypeFinders {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Reflection;

	public interface ITypeFinder {
		AppDomain App { get; }
		bool LoadAppDomainAssemblies { get; set; }
		IList<string> AssemblyNames { get; set; }
		string AssemblySkipLoadingPattern { get; set; }
		string AssemblyRestrictToLoadingPattern { get; set; }
		IEnumerable<Type> FindClassesOfType<TType>(bool onlyConcreteClasses = true);

		IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true);

		IEnumerable<Type> FindClassesOfType<TType>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

		IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true);

		IEnumerable<Type> FindClassesOfType<TType, TAssemblyAttribute>(bool onlyConcreteClasses = true) where TAssemblyAttribute : Attribute;
		IEnumerable<Assembly> FindAssembliesWithAttribute<TType>();
		IEnumerable<Assembly> FindAssembliesWithAttribute<TType>(IEnumerable<Assembly> assemblies);
		IEnumerable<Assembly> FindAssembliesWithAttribute<TType>(DirectoryInfo assemblyPath);
		IList<Assembly> GetAssemblies();
		bool Matches(string assemblyFullName);
	}
}