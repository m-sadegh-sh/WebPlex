namespace WebPlex.Services.Validations.Extensions {
	using WebPlex.Core.Domain.Entities;

	public static class DuplicationExtentions {
		public static bool IsDuplicate<T>(this T dbEntity, T originalEntity) where T : class, IEntity {
			return dbEntity != (originalEntity.IsTransient() ? null : originalEntity);
		}
	}
}