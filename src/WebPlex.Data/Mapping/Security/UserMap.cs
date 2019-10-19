namespace WebPlex.Data.Mapping.Security {
	using NHibernate.Mapping.ByCode;

	using WebPlex.Core.Domain.Entities.Security;

	public sealed class UserMap : EntityMapBase<UserEntity> {
		public UserMap() {
			Property(u => u.Email);

			ManyToOne(u => u.Membership, mto => {
				                             mto.Cascade(Cascade.All | Cascade.DeleteOrphans);
				                             mto.Unique(true);
			                             });

			SetController(u => u.OAuths);
			SetController(u => u.Roles);
		}
	}
}