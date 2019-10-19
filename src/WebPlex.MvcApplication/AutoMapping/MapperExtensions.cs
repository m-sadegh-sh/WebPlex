namespace WebPlex.MvcApplication.AutoMapping {
	using System;
	using System.Linq;

	using AutoMapper;

	public static class MapperExtensions {
		public static void InheritMappingFromBaseType<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression) {
			var sourceType = typeof (TSource);
			var desctinationType = typeof (TDestination);
			var sourceParentType = sourceType.BaseType;
			var destinationParentType = desctinationType.BaseType;

			mappingExpression.BeforeMap((source, destination) => Mapper.Map(source, destination, sourceParentType, destinationParentType)).ForAllMembers(mce => mce.Condition(rc => NotAlreadyMapped(sourceParentType, destinationParentType, rc)));
		}

		private static bool NotAlreadyMapped(Type sourceType, Type desitnationType, ResolutionContext resolutionContext) {
			return !resolutionContext.IsSourceValueNull && Mapper.FindTypeMapFor(sourceType, desitnationType).GetPropertyMaps().Where(pm => pm.DestinationProperty.Name.Equals(resolutionContext.MemberName)).Select(pm => !pm.IsMapped()).All(b => b);
		}
	}
}