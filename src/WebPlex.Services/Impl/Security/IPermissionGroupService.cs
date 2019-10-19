namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IPermissionGroupService : IDbService<PermissionGroupEntity> {
		PermissionGroupEntity Get(string name, bool inVisible, bool logIfNull);

		PermissionGroupEntity Get(Constant internalKey, bool inVisible, bool logIfNull);

		OperationResult<PermissionGroupEntity> Save(string name, Constant internalKey);

		OperationResult Delete(string name, bool onlyChangeFlag);

		OperationResult Delete(Constant internalKey, bool onlyChangeFlag);
	}
}