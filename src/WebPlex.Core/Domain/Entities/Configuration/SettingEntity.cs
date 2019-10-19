namespace WebPlex.Core.Domain.Entities.Configuration {
	using System;

	using WebPlex.Core.Extensions;

	public class SettingEntity : EntityBase {
		public virtual string Key { get; set; }
		public virtual string Value { get; set; }

		public virtual TValue As<TValue>(TValue defaultValue) {
			return ValueResolveHelpers.ResolveValue(this, defaultValue);
		}

		public override string ToString() {
			return string.Format("{0}: {1}", Key, Value);
		}

		public override bool Equals(object obj) {
			return Equals(obj as SettingEntity);
		}

		public virtual bool Equals(SettingEntity other) {
			if (other == null)
				return false;

			if (base.Equals(other))
				return true;

			return string.Equals(Key, other.Key, StringComparison.InvariantCultureIgnoreCase);
		}

		public override int GetHashCode() {
			return Key.NotNullOrDefault().GetHashCode();
		}
	}
}