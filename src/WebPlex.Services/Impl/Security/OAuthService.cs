namespace WebPlex.Services.Impl.Security {
	using System.Collections.Generic;

	using WebPlex.Core;
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class OAuthService : DbServiceBase<OAuthEntity>, IOAuthService {
		private readonly IWorkContext _workContext;

		public OAuthService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider, IWorkContext workContext) : base(activeSessionManager, validationProvider) {
			_workContext = workContext;
		}

		public OAuthEntity Get(Constant providerKey, Constant userKey, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(providerKey))
				return null;

			if (string.IsNullOrEmpty(userKey))
				return null;

			var oauth = Get(oa => oa.ProviderKey == providerKey && oa.UserKey == userKey, inVisible, logIfNull);

			return oauth;
		}

		public IList<OAuthEntity> GetAll(UserEntity user, bool inVisible) {
			return GetAll(oa => oa.User == user, inVisible);
		}

		public IList<OAuthEntity> GetAll(string email, bool inVisible) {
			return GetAll(oa => oa.User.Email == email, inVisible);
		}

		public OperationResult<OAuthEntity> Save(Constant providerKey, Constant userKey) {
			var user = _workContext.CurrentUser;

			return Save(providerKey, userKey, user);
		}

		public OperationResult<OAuthEntity> Save(Constant providerKey, Constant userKey, UserEntity user) {
			var result = EngineContext.Current.Resolve<OperationResult<OAuthEntity>>();

			var oauth = Get(providerKey, userKey, true, false);

			if (oauth == null) {
				oauth = new OAuthEntity {
						IsEnabled = true,
						ProviderKey = providerKey,
						UserKey = userKey
				};
			}

			oauth.User = user;

			result += Save(oauth, false);

			return result.With(oauth);
		}

		public OperationResult Delete(Constant providerKey, Constant userKey, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var oauth = Get(providerKey, userKey, true, true);

			if (oauth == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(oauth, onlyChangeFlag);

			return result;
		}

		protected override OAuthEntity GetDatabaseVersion(OAuthEntity oauth) {
			return Get(oauth.ProviderKey, oauth.UserKey, true, false);
		}
	}
}