namespace WebPlex.Services.Validations {
	using NHibernate.Validator.Cfg.Loquacious;

	using WebPlex.Core.Domain.Entities;

	public abstract class EntityValidationBase<T> : ValidationDef<T> where T : EntityBase {
		protected EntityValidationBase() {
			Define(e => e.Id);

			Define(e => e.Version);

			Define(e => e.DisplayOrder);

			Define(e => e.IsEnabled);
		}
	}
}