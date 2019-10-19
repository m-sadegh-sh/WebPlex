namespace WebPlex.Core {
	using System;

	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
	public sealed class ValueAttribute : Attribute {
		public ValueAttribute(string value) : this(null, value) {}

		public ValueAttribute(string key, string value) {
			Key = key;
			Value = value;
		}

		public string Key { get; private set; }
		public string Value { get; private set; }
	}
}