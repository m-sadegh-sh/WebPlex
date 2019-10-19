namespace WebPlex.Services.Security {
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Security;

	public interface IPermissionGroupProvider {
		IEnumerable<PermissionGroupEntity> GetAll();
		IEnumerable<DefaultPermissionGroup> GetDefaults();
	}
}