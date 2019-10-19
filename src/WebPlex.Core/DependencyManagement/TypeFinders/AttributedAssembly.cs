namespace WebPlex.Core.DependencyManagement.TypeFinders {
	using System;
	using System.Reflection;

	internal sealed class AttributedAssembly {
		public Assembly Assembly { get; set; }
		public Type PluginAttributeType { get; set; }
	}
}