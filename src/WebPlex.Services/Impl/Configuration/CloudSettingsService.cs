namespace WebPlex.Services.Impl.Configuration {
	using WebPlex.Core.Domain.Settings;

	public sealed class CloudSettingsService : DbSettingsServiceBase<CloudSettings>, ICloudSettingsService {
		public CloudSettingsService(ValidationProvider validationProvider, ISettingService settingService) : base(validationProvider, settingService) {}
	}
}