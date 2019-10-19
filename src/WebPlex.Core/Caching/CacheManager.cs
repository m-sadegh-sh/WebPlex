namespace WebPlex.Core.Caching {
	using System.Collections;
	using System.Collections.Generic;
	using System.Web.Caching;

	using CuttingEdge.Conditions;

	public sealed class CacheManager : ICacheManager {
		private readonly Cache _cache;

		public CacheManager(Cache source) {
			Condition.Requires(source).IsNotNull();

			_cache = source;
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public IEnumerator GetEnumerator() {
			return _cache.GetEnumerator();
		}

		public int Count {
			get { return _cache.Count; }
		}

		public bool Exists(string key) {
			return this[key] != null;
		}

		public void Add(string key, object value) {
			Condition.Requires(key).IsNotNullOrEmpty();
			Condition.Requires(value).IsNotNull();

			_cache.Insert(key, value);
		}

		public object this[string key] {
			get { return _cache[key]; }
			set { _cache[key] = value; }
		}

		public T Get<T>(string key) {
			if (Exists(key))
				return (T) _cache[key];

			return default(T);
		}

		public void Remove(string key) {
			_cache.Remove(key);
		}

		public void Clear() {
			var keys = new List<string>();

			var enumerator = _cache.GetEnumerator();

			while (enumerator.MoveNext())
				keys.Add(enumerator.Key.ToString());

			foreach (var key in keys)
				Remove(key);
		}
	}
}