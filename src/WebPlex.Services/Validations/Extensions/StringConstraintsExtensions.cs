namespace WebPlex.Services.Validations.Extensions {
	using NHibernate.Validator.Cfg.Loquacious;

	using WebPlex.Core;

	public static class StringConstraintsExtensions {
		public static IChainableConstraint<IStringConstraints> MaxLength(this IStringConstraints constraints) {
			return constraints.MaxLength(4000);
		}

		public static IChainableConstraint<IStringConstraints> IsIp(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidIp(v));
		}

		public static IChainableConstraint<IStringConstraints> IsEmail(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidEmail(v));
		}

		public static IChainableConstraint<IStringConstraints> IsUrl(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidUrl(v));
		}

		public static IChainableConstraint<IStringConstraints> IsPath(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidPath(v));
		}

		public static IChainableConstraint<IStringConstraints> IsTimeZoneId(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidTimeZoneId(v));
		}

		public static IChainableConstraint<IStringConstraints> IsCultureCode(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidCultureCode(v));
		}

		public static IChainableConstraint<IStringConstraints> IsSlug(this IStringConstraints constraints, bool ignoreEmpty = true) {
			return constraints.Satisfy(v => (ignoreEmpty && string.IsNullOrEmpty(v)) || PatternValidator.IsValidSlug(v));
		}
	}
}