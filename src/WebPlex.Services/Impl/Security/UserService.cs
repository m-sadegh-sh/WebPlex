namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Services.Infrastructure;

	public sealed class UserService : DbServiceBase<UserEntity>, IUserService {
		public UserService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public UserEntity Get(string email, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(email))
				return null;

			var user = Get(u => u.Email == email, inVisible, logIfNull);

			return user;
		}

		public OperationResult<UserEntity> Save(string email) {
			var result = EngineContext.Current.Resolve<OperationResult<UserEntity>>();

			var user = Get(email, true, false);

			if (user == null) {
				user = new UserEntity {
						IsEnabled = true,
						Email = email
				};
			}

			result += Save(user, false);

			return result.With(user);
		}

		public OperationResult Delete(string email, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var user = Get(email, true, true);

			result += Delete(user, onlyChangeFlag);

			return result;
		}

		protected override UserEntity GetDatabaseVersion(UserEntity user) {
			return Get(user.Email, true, false);
		}
	}
}