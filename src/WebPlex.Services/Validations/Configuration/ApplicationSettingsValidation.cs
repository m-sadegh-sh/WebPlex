namespace WebPlex.Services.Validations.Configuration {
	using NHibernate.Validator.Cfg.Loquacious;

	using WebPlex.Core.Domain.Settings;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;
	using WebPlex.Services.Validations.Extensions;

	public sealed class ApplicationSettingsValidation : ValidationDef<ApplicationSettings> {
		public ApplicationSettingsValidation() {
			Define(@as => @as.DefaultTimeZoneId).IsTimeZoneId().WithMessage(ValidationHelpers.InvalidTimeZoneId(Members.ApplicationSettings_DefaultTimeZoneId));

			Define(@as => @as.AllowUsersToSetTimeZone);

			Define(@as => @as.DefaultLanguage).IsCultureCode().WithMessage(ValidationHelpers.InvalidCultureCode(Members.ApplicationSettings_DefaultLanguage));

			Define(@as => @as.AllowUsersToSetLanguage);

			Define(@as => @as.TitleSeparator);
		}
	}
}