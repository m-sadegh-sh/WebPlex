namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class PermissionGroupMap : EntityMapBase<PermissionGroupEntity> {
		public PermissionGroupMap() {
			Property(pg => pg.Name);
			Property(pg => pg.InternalKey, pm => pm.Type<ConstantType>());
			SetController(pg => pg.Roles);
		}
	}
}