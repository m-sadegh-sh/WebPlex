namespace WebPlex.Services.Validations.Extensions {
	using NHibernate.Validator.Cfg.Loquacious;

	public static class CollectionConstraintsExtensions {
		public static IRuleArgsOptions MaxSize(this ICollectionConstraints constraints) {
			return constraints.MaxSize(4000);
		}
	}
}