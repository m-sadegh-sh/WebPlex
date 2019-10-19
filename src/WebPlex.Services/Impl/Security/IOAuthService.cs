namespace WebPlex.Services.Impl.Security {
	using System.Collections.Generic;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IOAuthService : IDbService<OAuthEntity> {
		OAuthEntity Get(Constant providerKey, Constant userKey, bool inVisible, bool logIfNull);

		IList<OAuthEntity> GetAll(UserEntity user, bool inVisible);

		IList<OAuthEntity> GetAll(string email, bool inVisible);

		OperationResult<OAuthEntity> Save(Constant providerKey, Constant userKey);

		OperationResult<OAuthEntity> Save(Constant providerKey, Constant userKey, UserEntity user);

		OperationResult Delete(Constant providerKey, Constant userKey, bool onlyChangeFlag);
	}
}