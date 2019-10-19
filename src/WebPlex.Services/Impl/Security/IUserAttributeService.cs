namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IUserAttributeService : IDbService<UserAttributeEntity> {
		TValue GetValue<TValue>(long id, TValue defaultValue, bool load, bool inVisible, bool logIfNull);

		UserAttributeEntity Get(string email, UserAttribute key, bool inVisible, bool logIfNull);

		TValue GetValue<TValue>(string email, UserAttribute key, TValue defaultValue, bool inVisible, bool logIfNull);

		UserAttributeEntity Get(UserEntity user, UserAttribute key, bool inVisible, bool logIfNull);

		TValue GetValue<TValue>(UserEntity user, UserAttribute key, TValue defaultValue, bool inVisible, bool logIfNull);

		OperationResult<UserAttributeEntity> Save<TValue>(string email, UserAttribute key, TValue value);

		OperationResult<UserAttributeEntity> Save<TValue>(UserEntity user, UserAttribute key, TValue value);

		OperationResult Delete(string email, UserAttribute key, bool onlyChangeFlag);

		OperationResult Delete(UserEntity user, UserAttribute key, bool onlyChangeFlag);
	}
}