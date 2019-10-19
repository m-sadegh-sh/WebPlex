namespace WebPlex.Data {
	using System;

	using Autofac;

	using WebPlex.Data.Mapping;

	public static class MappingExtensions {
		public static bool IsMappingType(this Type type) {
			if (type == null)
				return false;

			if (!type.IsClass)
				return false;

			if (type.IsAbstract)
				return false;

			if (type.IsAssignableTo<IClassMapper>())
				return true;

			return false;
		}
	}
}