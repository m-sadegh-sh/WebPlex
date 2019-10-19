namespace WebPlex.Core.Caching {
	using System.Collections;

	public interface ICacheManager : IEnumerable {
		int Count { get; }
		bool Exists(string key);

		void Add(string key, object value);

		object this[string key] { get; set; }
		T Get<T>(string key);
		void Remove(string key);
		void Clear();
	}
}