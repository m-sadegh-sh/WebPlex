namespace WebPlex.Services {
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Services.Infrastructure;

	public interface IDbSettingsService<out TSettings> where TSettings : class, ISettings, new() {
		TSettings Instance { get; }
		OperationResult SaveChanges();
	}
}