namespace WebPlex.Services.Impl.Configuration {
	using WebPlex.Core.Domain.Entities.Configuration;
	using WebPlex.Services.Infrastructure;

	public interface ISettingService : IDbService<SettingEntity> {
		SettingEntity Get(string key, bool inVisible, bool logIfNull);

		TValue GetValue<TValue>(string key, TValue defaultValue, bool inVisible, bool logIfNull);

		OperationResult<SettingEntity> Save<TValue>(string key, TValue value);

		OperationResult Delete(string key, bool onlyChangeFlag);
	}
}