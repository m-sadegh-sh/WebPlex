namespace WebPlex.Services {
	using System;
	using System.Linq;

	using TB.ComponentModel;

	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Configuration;
	using WebPlex.Services.Infrastructure;

	public abstract class DbSettingsServiceBase<TSettings> : IDbSettingsService<TSettings> where TSettings : class, ISettings, new() {
		private static TSettings _cachedSettings;

		private readonly ValidationProvider _validationProvider;
		private readonly ISettingService _settingService;

		protected DbSettingsServiceBase(ValidationProvider validationProvider, ISettingService settingService) {
			_validationProvider = validationProvider;
			_settingService = settingService;
		}

		public TSettings Instance {
			get {
				if (_cachedSettings == null)
					_cachedSettings = ReloadSettings();

				return _cachedSettings;
			}
		}

		public OperationResult SaveChanges() {
			var result = EngineContext.Current.Resolve<OperationResult>();

			if (_cachedSettings == null)
				return result.AddError(Messages.Common_NullEntity);

			result += _validationProvider.Validate(_cachedSettings);

			if (result.ContainsError)
				return result;

			try {
				var properties = from pi in typeof (TSettings).GetProperties()
					where pi.CanWrite && pi.CanRead
					select pi;

				var typeName = typeof (TSettings).Name;

				foreach (var property in properties) {
					var key = string.Concat(typeName, ".", property.Name);
					var value = property.GetValue(_cachedSettings, null);

					result += _settingService.Save(key, value);
				}
			} catch {
				return result;
			}

			return result;
		}

		private TSettings ReloadSettings() {
			var settings = Activator.CreateInstance<TSettings>();

			var properties = from pi in typeof (TSettings).GetProperties()
				where pi.CanWrite && pi.CanRead
				let key = string.Concat(typeof (TSettings).Name, ".", pi.Name)
				let setting = _settingService.GetValue<string>(key, null, false, true)
				where setting != null
				where UniversalTypeConverter.CanConvert(setting, pi.PropertyType)
				let value = UniversalTypeConverter.Convert(setting, pi.PropertyType)
				select new {
						PropertyInfo = pi,
						Value = value
				};

			properties.ToList().ForEach(p => p.PropertyInfo.SetValue(settings, p.Value, null));

			return settings;
		}
	}
}