namespace WebPlex.Services.Impl.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class RoleService : DbServiceBase<RoleEntity>, IRoleService {
		public RoleService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public RoleEntity Get(string name, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(name))
				return null;

			var role = Get(r => r.Name == name, inVisible, logIfNull);

			return role;
		}

		public RoleEntity Get(Constant internalKey, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(internalKey))
				return null;

			var role = Get(r => r.InternalKey == internalKey, inVisible, logIfNull);

			return role;
		}

		public OperationResult<RoleEntity> Save(string name, Constant internalKey) {
			var result = EngineContext.Current.Resolve<OperationResult<RoleEntity>>();

			var role = Get(internalKey, true, false);

			if (role == null) {
				role = new RoleEntity {
						IsEnabled = true,
						InternalKey = internalKey
				};
			}

			role.Name = name;

			result += Save(role, false);

			return result.With(role);
		}

		public OperationResult Delete(string name, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var role = Get(name, true, true);

			if (role == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(role, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(Constant internalKey, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var role = Get(internalKey, true, true);

			if (role == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(role, onlyChangeFlag);

			return result;
		}

		protected override RoleEntity GetDatabaseVersion(RoleEntity role) {
			return Get(role.InternalKey, true, false);
		}
	}
}