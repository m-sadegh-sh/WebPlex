namespace WebPlex.Core.Domain {
	using TB.ComponentModel;

	using WebPlex.Core.Domain.Entities;
	using WebPlex.Core.Domain.Entities.Configuration;

	public static class ValueResolveHelpers {
		public static TValue ResolveValue<TValue>(SettingEntity setting, TValue defaultValue) {
			if (setting == null)
				return defaultValue;

			if (!setting.Value.CanConvertTo<TValue>())
				return defaultValue;

			var convertedValue = setting.Value.ConvertTo<TValue>();

			return convertedValue;
		}

		public static TValue ResolveValue<TKey, TValue>(AttributeEntityBase<TKey> attribute, TValue defaultValue) where TKey : struct {
			if (attribute == null)
				return defaultValue;

			if (!attribute.Value.CanConvertTo<TValue>())
				return defaultValue;

			var convertedValue = attribute.Value.ConvertTo<TValue>();

			return convertedValue;
		}
	}
}