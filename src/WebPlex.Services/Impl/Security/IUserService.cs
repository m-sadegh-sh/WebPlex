namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IUserService : IDbService<UserEntity> {
		UserEntity Get(string email, bool inVisible, bool logIfNull);

		OperationResult<UserEntity> Save(string email);

		OperationResult Delete(string email, bool onlyChangeFlag);
	}
}