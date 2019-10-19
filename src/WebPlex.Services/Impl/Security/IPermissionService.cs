namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IPermissionService : IDbService<PermissionEntity> {
		PermissionEntity Get(string name, bool inVisible, bool logIfNull);

		PermissionEntity Get(Constant internalKey, bool inVisible, bool logIfNull);

		OperationResult<PermissionEntity> Save(string name, Constant internalKey, PermissionGroupEntity group);

		OperationResult Delete(string name, bool onlyChangeFlag);

		OperationResult Delete(Constant internalKey, bool onlyChangeFlag);
	}
}