namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class OAuthTokenMap : EntityMapBase<OAuthTokenEntity> {
		public OAuthTokenMap() {
			Property(oat => oat.Token, pm => pm.Type<ConstantType>());
			Property(oat => oat.Secret, pm => pm.Type<ConstantType>());
		}
	}
}