namespace WebPlex.Core.DependencyManagement.TypeFinders {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Text;
	using System.Text.RegularExpressions;

	public class AppDomainTypeFinder : ITypeFinder {
		private readonly IList<Type> _assemblyAttributesSearched = new List<Type>();
		private readonly IList<AttributedAssembly> _attributedAssemblies = new List<AttributedAssembly>();

		public AppDomainTypeFinder() {
			AssemblyRestrictToLoadingPattern = "WebPlex.*";
			AssemblySkipLoadingPattern =
					"^System|^mscorlib|^Microsoft|^CppCodeProvider|^VJSharpCodeProvider|^WebDev|^Castle|^Iesi|^log4net|^NHibernate|^nunit|^TestDriven|^MbUnit|^Rhino|^QuickGraph|^TestFu|^Telerik|^ComponentArt|^MvcContrib|^AjaxControlToolkit|^Antlr3|^Remotion|^Recaptcha";
			LoadAppDomainAssemblies = true;
			AssemblyNames = new List<string>();
		}

		public virtual AppDomain App {
			get { return AppDomain.CurrentDomain; }
		}

		public bool LoadAppDomainAssemblies { get; set; }

		public IList<string> AssemblyNames { get; set; }

		public string AssemblySkipLoadingPattern { get; set; }

		public string AssemblyRestrictToLoadingPattern { get; set; }

		public IEnumerable<Type> FindClassesOfType<TType>(bool onlyConcreteClasses = true) {
			return FindClassesOfType(typeof (TType), onlyConcreteClasses);
		}

		public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, bool onlyConcreteClasses = true) {
			return FindClassesOfType(assignTypeFrom, GetAssemblies(), onlyConcreteClasses);
		}

		public IEnumerable<Type> FindClassesOfType<TType>(IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true) {
			return FindClassesOfType(typeof (TType), assemblies, onlyConcreteClasses);
		}

		public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true) {
			var result = new List<Type>();
			try {
				foreach (var type in from assembly in assemblies
					from types in assembly.GetTypes()
					where assignTypeFrom.IsAssignableFrom(types) || (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(types, assignTypeFrom))
					where !types.IsInterface
					select types) {
					if (onlyConcreteClasses) {
						if (type.IsClass && !type.IsAbstract)
							result.Add(type);
					} else
						result.Add(type);
				}
			} catch (ReflectionTypeLoadException e) {
				var message = new StringBuilder();

				foreach (var loaderException in e.LoaderExceptions)
					message.AppendLine(loaderException.Message);

				var exception = new Exception(message.ToString(), e);

				throw exception;
			}

			return result;
		}

		public IEnumerable<Type> FindClassesOfType<TType, TAssemblyAttribute>(bool onlyConcreteClasses = true) where TAssemblyAttribute : Attribute {
			var found = FindAssembliesWithAttribute<TAssemblyAttribute>();

			return FindClassesOfType<TType>(found, onlyConcreteClasses);
		}

		public IEnumerable<Assembly> FindAssembliesWithAttribute<TType>() {
			return FindAssembliesWithAttribute<TType>(GetAssemblies());
		}

		public IEnumerable<Assembly> FindAssembliesWithAttribute<TType>(IEnumerable<Assembly> assemblies) {
			if (!_assemblyAttributesSearched.Contains(typeof (TType))) {
				var foundAssemblies = (from assembly in assemblies
					let customAttributes = assembly.GetCustomAttributes(typeof (TType), false)
					where customAttributes.Any()
					select assembly).ToList();

				_assemblyAttributesSearched.Add(typeof (TType));

				foreach (var assembly in foundAssemblies) {
					_attributedAssemblies.Add(new AttributedAssembly {
							Assembly = assembly,
							PluginAttributeType = typeof (TType)
					});
				}
			}

			return _attributedAssemblies.Where(aa => aa.PluginAttributeType == typeof (TType)).Select(aa => aa.Assembly).ToList();
		}

		public IEnumerable<Assembly> FindAssembliesWithAttribute<TType>(DirectoryInfo assemblyPath) {
			var assemblies = (from path in Directory.GetFiles(assemblyPath.FullName, "*.dll")
				select Assembly.LoadFrom(path)
				into assembly let customAttributes = assembly.GetCustomAttributes(typeof (TType), false) where customAttributes.Any() select assembly).ToList();

			return FindAssembliesWithAttribute<TType>(assemblies);
		}

		public virtual IList<Assembly> GetAssemblies() {
			var addedAssemblyNames = new List<string>();
			var assemblies = new List<Assembly>();

			if (LoadAppDomainAssemblies)
				AddAssembliesInAppDomain(addedAssemblyNames, assemblies);

			AddConfiguredAssemblies(addedAssemblyNames, assemblies);

			return assemblies;
		}

		public virtual bool Matches(string assemblyFullName) {
			return !Matches(assemblyFullName, AssemblySkipLoadingPattern) && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
		}

		protected virtual void AddConfiguredAssemblies(IList<string> addedAssemblyNames, List<Assembly> assemblies) {
			foreach (var assembly in AssemblyNames.Select(Assembly.Load)) {
				if (!addedAssemblyNames.Contains(assembly.FullName)) {
					assemblies.Add(assembly);
					addedAssemblyNames.Add(assembly.FullName);
				}
			}
		}

		protected virtual bool Matches(string assemblyFullName, string pattern) {
			return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
		}

		protected virtual void LoadMatchingAssemblies(string directoryPath) {
			var loadedAssemblyNames = new List<string>();
			foreach (var assembly in GetAssemblies())
				loadedAssemblyNames.Add(assembly.FullName);

			if (!Directory.Exists(directoryPath))
				return;

			foreach (var dllPath in Directory.GetFiles(directoryPath, "*.dll")) {
				try {
					var assemblyName = AssemblyName.GetAssemblyName(dllPath);

					if (Matches(assemblyName.FullName) && !loadedAssemblyNames.Contains(assemblyName.FullName))
						App.Load(assemblyName);
				} catch (BadImageFormatException) {}
			}
		}

		protected virtual bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric) {
			try {
				var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();

				return (from implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null)
					where implementedInterface.IsGenericType
					select genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition())).FirstOrDefault();
			} catch {
				return false;
			}
		}

		private void AddAssembliesInAppDomain(ICollection<string> addedAssemblyNames, ICollection<Assembly> assemblies) {
			foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				if (!Matches(assembly.FullName))
					continue;

				if (addedAssemblyNames.Contains(assembly.FullName))
					continue;

				assemblies.Add(assembly);
				addedAssemblyNames.Add(assembly.FullName);
			}
		}
	}
}