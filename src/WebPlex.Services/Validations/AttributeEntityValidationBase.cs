namespace WebPlex.Services.Validations {
	using WebPlex.Core.Domain.Entities;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public abstract class AttributeEntityValidationBase<TEntity, TKey> : EntityValidationBase<TEntity> where TEntity : AttributeEntityBase<TKey> where TKey : struct {
		protected AttributeEntityValidationBase() {
			Define(a => a.Key);

			Define(a => a.Value).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.AttributeEntityBase_Value));
		}
	}
}