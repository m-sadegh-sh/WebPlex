namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class PermissionService : DbServiceBase<PermissionEntity>, IPermissionService {
		public PermissionService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public PermissionEntity Get(string name, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(name))
				return null;

			var permission = Get(p => p.Name == name, inVisible, logIfNull);

			return permission;
		}

		public PermissionEntity Get(Constant internalKey, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(internalKey))
				return null;

			var permission = Get(p => p.InternalKey == internalKey, inVisible, logIfNull);

			return permission;
		}

		public OperationResult<PermissionEntity> Save(string name, Constant internalKey, PermissionGroupEntity group) {
			var result = EngineContext.Current.Resolve<OperationResult<PermissionEntity>>();

			var permission = Get(internalKey, true, false);

			if (permission == null) {
				permission = new PermissionEntity {
						IsEnabled = true,
						InternalKey = internalKey
				};
			}

			permission.Name = name;
			permission.Group = group;

			result += Save(permission, false);

			return result.With(permission);
		}

		public OperationResult Delete(string name, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var permisison = Get(name, true, true);

			if (permisison == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(permisison, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(Constant internalKey, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var permisison = Get(internalKey, true, true);

			if (permisison == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(permisison, onlyChangeFlag);

			return result;
		}

		protected override PermissionEntity GetDatabaseVersion(PermissionEntity permission) {
			return Get(permission.InternalKey, true, false);
		}
	}
}