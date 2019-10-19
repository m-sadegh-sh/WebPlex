namespace WebPlex.Data.Mapping.Configuration {
	using WebPlex.Core.Domain.Entities.Configuration;

	public sealed class SettingMap : EntityMapBase<SettingEntity> {
		public SettingMap() {
			Property(s => s.Key);
			Property(s => s.Value);
		}
	}
}