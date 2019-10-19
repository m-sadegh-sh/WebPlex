namespace WebPlex.Services.Security {
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Security;

	public interface IPermissionProvider {
		IEnumerable<PermissionEntity> GetAll();
		IEnumerable<DefaultPermission> GetDefaults();
	}
}