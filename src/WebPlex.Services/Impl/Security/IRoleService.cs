namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IRoleService : IDbService<RoleEntity> {
		RoleEntity Get(string name, bool inVisible, bool logIfNull);

		RoleEntity Get(Constant internalKey, bool inVisible, bool logIfNull);

		OperationResult<RoleEntity> Save(string name, Constant internalKey);

		OperationResult Delete(string name, bool onlyChangeFlag);

		OperationResult Delete(Constant internalKey, bool onlyChangeFlag);
	}
}