namespace WebPlex.Services.Validations.Configuration {
	using NHibernate.Validator.Cfg.Loquacious;

	using WebPlex.Core.Domain.Settings;
	using WebPlex.Services.Validations.Extensions;

	public sealed class ContactFormSettingsValidation : ValidationDef<ContactFormSettings> {
		public ContactFormSettingsValidation() {
			Define(cf => cf.RecipientName);

			Define(cf => cf.Subject).MaxLength();
		}
	}
}