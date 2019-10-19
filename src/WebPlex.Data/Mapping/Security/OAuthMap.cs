namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class OAuthMap : EntityMapBase<OAuthEntity> {
		public OAuthMap() {
			Property(oa => oa.ProviderKey, pm => pm.Type<ConstantType>());
			Property(oa => oa.UserKey, pm => pm.Type<ConstantType>());
			ManyToOne(oa => oa.User);
		}
	}
}