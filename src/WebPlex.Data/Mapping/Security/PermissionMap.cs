namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class PermissionMap : EntityMapBase<PermissionEntity> {
		public PermissionMap() {
			Property(p => p.Name);
			Property(p => p.InternalKey, pm => pm.Type<ConstantType>());
			ManyToOne(p => p.Group);
			SetController(p => p.Roles);
		}
	}
}