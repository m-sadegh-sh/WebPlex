namespace WebPlex.Services.Impl.Security {
	using TB.ComponentModel;

	using WebPlex.Core.Domain;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class UserAttributeService : DbServiceBase<UserAttributeEntity>, IUserAttributeService {
		public UserAttributeService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public TValue GetValue<TValue>(long id, TValue defaultValue, bool load, bool inVisible, bool logIfNull) {
			var userAttribute = Get(id, load, inVisible, logIfNull);

			return ValueResolveHelpers.ResolveValue(userAttribute, defaultValue);
		}

		public UserAttributeEntity Get(string email, UserAttribute key, bool inVisible, bool logIfNull) {
			var user = EngineContext.Current.Resolve<IUserService>().Get(email, true, true);

			return Get(user, key, inVisible, logIfNull);
		}

		public TValue GetValue<TValue>(string email, UserAttribute key, TValue defaultValue, bool inVisible, bool logIfNull) {
			var user = EngineContext.Current.Resolve<IUserService>().Get(email, true, true);

			return GetValue(user, key, defaultValue, inVisible, logIfNull);
		}

		public UserAttributeEntity Get(UserEntity user, UserAttribute key, bool inVisible, bool logIfNull) {
			if (user == null)
				return null;

			var userAttribute = Get(ua => ua.User == user && ua.Key == key, inVisible, logIfNull);

			return userAttribute;
		}

		public TValue GetValue<TValue>(UserEntity user, UserAttribute key, TValue defaultValue, bool inVisible, bool logIfNull) {
			var userAttribute = Get(user, key, inVisible, logIfNull);

			return ValueResolveHelpers.ResolveValue(userAttribute, defaultValue);
		}

		public OperationResult<UserAttributeEntity> Save<TValue>(string email, UserAttribute key, TValue value) {
			var user = EngineContext.Current.Resolve<IUserService>().Get(email, true, true);

			return Save(user, key, value);
		}

		public OperationResult<UserAttributeEntity> Save<TValue>(UserEntity user, UserAttribute key, TValue value) {
			var result = EngineContext.Current.Resolve<OperationResult<UserAttributeEntity>>();

			if (!value.CanConvertTo<string>())
				return result.AddError(Messages.UserAttributes_NotSupportedValueType);

			var userAttribute = Get(user, key, true, false);

			if (userAttribute == null) {
				userAttribute = new UserAttributeEntity {
						IsEnabled = true,
						User = user,
						Key = key
				};
			}

			userAttribute.Value = value.ConvertTo<string>();

			result += Save(userAttribute, false);

			return result.With(userAttribute);
		}

		public OperationResult Delete(string email, UserAttribute key, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var user = EngineContext.Current.Resolve<IUserService>().Get(email, true, true);

			result += Delete(user, key, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(UserEntity user, UserAttribute key, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var userAttribute = Get(user, key, true, true);

			result += Delete(userAttribute, onlyChangeFlag);

			return result;
		}

		protected override UserAttributeEntity GetDatabaseVersion(UserAttributeEntity userAttribute) {
			return Get(userAttribute.User, userAttribute.Key, true, false);
		}
	}
}