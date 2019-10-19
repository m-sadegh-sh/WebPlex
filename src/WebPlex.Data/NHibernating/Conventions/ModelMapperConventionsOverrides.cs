namespace WebPlex.Data.NHibernating.Conventions {
	using System;

	using NHibernate.Mapping.ByCode;

	using WebPlex.Core.Extensions;

	public static class ModelMapperConventionsOverrides {
		public static void ApplyNamingConventions(this ModelMapper modelMapper) {
			modelMapper.BeforeMapClass += ClassConvention;
			modelMapper.BeforeMapProperty += PropertyConvension;
			modelMapper.BeforeMapManyToOne += ReferenceConvention;
			modelMapper.BeforeMapSet += OneToManyConvention;
			modelMapper.BeforeMapJoinedSubclass += JoinedSubclassConvention;
		}

		private static void ClassConvention(IModelInspector modelInspector, Type type, IClassAttributesMapper classAttributesMapper) {
			var schema = IdentityBuilder.BuildSchema(type.Namespace);
			classAttributesMapper.Schema(schema);

			var tableName = IdentityBuilder.BuildTableName(type.Name);
			classAttributesMapper.Table(tableName);

			classAttributesMapper.Id(im => {
				                         im.Generator(Generators.Assigned);
				                         im.Column(IdentityBuilder.BuildPrimaryKey(type.Name));
			                         });
		}

		private static void PropertyConvension(IModelInspector modelInspector, PropertyPath propertyPath, IPropertyMapper propertyMapper) {
			if (modelInspector.IsSet(propertyPath.LocalMember))
				propertyMapper.Access(Accessor.Field);

			var type = propertyPath.LocalMember.GetPropertyOrFieldType();

			if (!type.IsNullable())
				propertyMapper.NotNullable(true);

			var propertyName = propertyPath.LocalMember.Name;
			if (modelInspector.IsComponent(propertyPath.LocalMember.ReflectedType)) {
				var entityName = propertyPath.LocalMember.ReflectedType.Name;

				propertyMapper.Column(IdentityBuilder.BuildColumnName(entityName, propertyName));
			} else
				propertyMapper.Column(IdentityBuilder.BuildColumnName(propertyName));
		}

		private static void ReferenceConvention(IModelInspector modelInspector, PropertyPath propertyPath, IManyToOneMapper manyToOneMapper) {
			manyToOneMapper.Column(cm => cm.Name(IdentityBuilder.BuildPrimaryKey(propertyPath.LocalMember.Name)));
		}

		private static void OneToManyConvention(IModelInspector modelInspector, PropertyPath propertyPath, ISetPropertiesMapper setPropertiesMapper) {
			var propertyInfo = propertyPath.LocalMember.GetInverseProperty();

			if (propertyInfo == null) {
				setPropertiesMapper.Key(km => km.Column(IdentityBuilder.BuildPrimaryKey(propertyPath.GetContainerEntity(modelInspector).Name)));
				setPropertiesMapper.Cascade(Cascade.All | Cascade.DeleteOrphans);
				setPropertiesMapper.BatchSize(20);
				setPropertiesMapper.Inverse(true);
			}
		}

		private static void JoinedSubclassConvention(IModelInspector modelInspector, Type type, IJoinedSubclassAttributesMapper joinedSubclassAttributesMapper) {
			var schema = IdentityBuilder.BuildSchema(type.Namespace);
			joinedSubclassAttributesMapper.Schema(schema);

			var tableName = IdentityBuilder.BuildTableName(type.Name);
			joinedSubclassAttributesMapper.Table(tableName);

			joinedSubclassAttributesMapper.Key(km => km.Column(IdentityBuilder.BuildPrimaryKey(type.Name)));
		}
	}
}