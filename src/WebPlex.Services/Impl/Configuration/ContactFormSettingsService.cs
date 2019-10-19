namespace WebPlex.Services.Impl.Configuration {
	using WebPlex.Core.Domain.Settings;

	public sealed class ContactFormSettingsService : DbSettingsServiceBase<ContactFormSettings>, IContactFormSettingsService {
		public ContactFormSettingsService(ValidationProvider validationProvider, ISettingService settingService) : base(validationProvider, settingService) {}
	}
}