namespace WebPlex.Data.NHibernating.Conventions {
	using System.Linq;
	using System.Reflection;

	using NHibernate.Mapping.ByCode;

	public static class ManyToManyHelpers {
		public static PropertyInfo GetInverseProperty(this PropertyInfo propertyInfo) {
			var type = propertyInfo.PropertyType;
			var to = type.DetermineCollectionElementOrDictionaryValueType();

			if (to == null)
				return null;

			var expectedInversePropertyType = type.GetGenericTypeDefinition().MakeGenericType(propertyInfo.DeclaringType);

			var argument = type.GetGenericArguments()[0];

			return argument.GetProperties().FirstOrDefault(pi => pi.PropertyType == expectedInversePropertyType && pi != propertyInfo);
		}

		public static PropertyInfo GetInverseProperty(this MemberInfo memberInfo) {
			var type = memberInfo.GetPropertyOrFieldType();
			var to = type.DetermineCollectionElementOrDictionaryValueType();

			if (to == null)
				return null;

			var expectedInversePropertyType = type.GetGenericTypeDefinition().MakeGenericType(memberInfo.DeclaringType);

			var argument = type.GetGenericArguments()[0];

			return argument.GetProperties().FirstOrDefault(pi => pi.PropertyType == expectedInversePropertyType);
		}
	}
}