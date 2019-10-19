namespace WebPlex.Services.Impl.Configuration {
	using TB.ComponentModel;

	using WebPlex.Core.Domain;
	using WebPlex.Core.Domain.Entities.Configuration;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class SettingService : DbServiceBase<SettingEntity>, ISettingService {
		public SettingService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public SettingEntity Get(string key, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(key))
				return null;

			var setting = Get(s => s.Key == key, inVisible, logIfNull);

			return setting;
		}

		public TValue GetValue<TValue>(string key, TValue defaultValue, bool inVisible, bool logIfNull) {
			var setting = Get(key, inVisible, logIfNull);

			return ValueResolveHelpers.ResolveValue(setting, defaultValue);
		}

		public OperationResult<SettingEntity> Save<TValue>(string key, TValue value) {
			var result = EngineContext.Current.Resolve<OperationResult<SettingEntity>>();

			if (!value.CanConvertTo<string>())
				return result.AddError(Messages.Settings_NotSupportedValueType);

			var setting = Get(key, true, false);

			if (setting == null) {
				setting = new SettingEntity {
						IsEnabled = true,
						Key = key
				};
			}

			setting.Value = value.ConvertTo<string>();

			result += Save(setting, false);

			return result.With(setting);
		}

		public OperationResult Delete(string key, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var setting = Get(key, true, true);

			if (setting == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(setting, onlyChangeFlag);

			return result;
		}

		protected override SettingEntity GetDatabaseVersion(SettingEntity setting) {
			return Get(setting.Key, true, false);
		}
	}
}