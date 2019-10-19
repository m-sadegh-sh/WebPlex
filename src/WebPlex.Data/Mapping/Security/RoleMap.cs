namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class RoleMap : EntityMapBase<RoleEntity> {
		public RoleMap() {
			Property(r => r.Name);
			Property(r => r.InternalKey, pm => pm.Type<ConstantType>());
			SetInverse(r => r.Groups, pg => pg.Roles);
			SetInverse(r => r.Permissions, p => p.Roles);
			SetInverse(r => r.Users, u => u.Roles);
		}
	}
}