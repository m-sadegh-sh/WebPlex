namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IOAuthTokenService : IDbService<OAuthTokenEntity> {
		OAuthTokenEntity Get(Constant token, bool inVisible, bool logIfNull);

		OperationResult<OAuthTokenEntity> Save(Constant token, Constant secret);

		OperationResult Delete(Constant token, bool onlyChangeFlag);
	}
}