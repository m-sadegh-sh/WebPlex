namespace WebPlex.Core.Caching {
	using System;
	using System.Globalization;
	using System.Linq;

	using CuttingEdge.Conditions;

	public static class CacheExtensions {
		public static T Get<T>(this ICacheManager cacheManager, Func<T> acquire, string key, params object[] args) {
			Condition.Requires(cacheManager).IsNotNull();
			Condition.Requires(acquire).IsNotNull();
			Condition.Requires(key).IsNotNullOrWhiteSpace();

			if (args != null && args.Any())
				key = string.Format(CultureInfo.InvariantCulture, key, args);

			if (cacheManager.Exists(key))
				return cacheManager.Get<T>(key);

			var value = acquire();

			cacheManager.Add(key, value);

			return value;
		}
	}
}