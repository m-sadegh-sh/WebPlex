namespace WebPlex.Services.Impl.Configuration {
	using WebPlex.Core.Domain.Settings;

	public sealed class ApplicationSettingsService : DbSettingsServiceBase<ApplicationSettings>, IApplicationSettingsService {
		public ApplicationSettingsService(ValidationProvider validationProvider, ISettingService settingService) : base(validationProvider, settingService) {}
	}
}