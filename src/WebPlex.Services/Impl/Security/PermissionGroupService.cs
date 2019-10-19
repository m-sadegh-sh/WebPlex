namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class PermissionGroupService : DbServiceBase<PermissionGroupEntity>, IPermissionGroupService {
		public PermissionGroupService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public PermissionGroupEntity Get(string name, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(name))
				return null;

			var group = Get(pg => pg.Name == name, inVisible, logIfNull);

			return group;
		}

		public PermissionGroupEntity Get(Constant internalKey, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(internalKey))
				return null;

			var group = Get(pg => pg.InternalKey == internalKey, inVisible, logIfNull);

			return group;
		}

		public OperationResult<PermissionGroupEntity> Save(string name, Constant internalKey) {
			var result = EngineContext.Current.Resolve<OperationResult<PermissionGroupEntity>>();

			var permissionGroup = Get(internalKey, true, false);

			if (permissionGroup == null) {
				permissionGroup = new PermissionGroupEntity {
						IsEnabled = true,
						InternalKey = internalKey,
				};
			}

			permissionGroup.Name = name;

			result += Save(permissionGroup, false);

			return result.With(permissionGroup);
		}

		public OperationResult Delete(string name, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var group = Get(name, true, true);

			if (group == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(group, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(Constant internalKey, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var group = Get(internalKey, true, true);

			if (group == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(group, onlyChangeFlag);

			return result;
		}

		protected override PermissionGroupEntity GetDatabaseVersion(PermissionGroupEntity group) {
			return Get(group.InternalKey, true, false);
		}
	}
}