namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class OAuthTokenService : DbServiceBase<OAuthTokenEntity>, IOAuthTokenService {
		public OAuthTokenService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public OAuthTokenEntity Get(Constant token, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(token))
				return null;

			var oauthToken = Get(oat => oat.Token == token, inVisible, logIfNull);

			return oauthToken;
		}

		public OperationResult<OAuthTokenEntity> Save(Constant token, Constant secret) {
			var result = EngineContext.Current.Resolve<OperationResult<OAuthTokenEntity>>();

			var oauthToken = Get(token, true, false);

			if (oauthToken == null) {
				oauthToken = new OAuthTokenEntity {
						IsEnabled = true,
						Token = token,
				};
			}

			oauthToken.Secret = secret;

			result += Save(oauthToken, false);

			return result.With(oauthToken);
		}

		public OperationResult Delete(Constant token, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var oauthToken = Get(token, true, true);

			if (oauthToken == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(oauthToken, onlyChangeFlag);

			return result;
		}

		protected override OAuthTokenEntity GetDatabaseVersion(OAuthTokenEntity oauthToken) {
			return Get(oauthToken.Token, true, false);
		}
	}
}