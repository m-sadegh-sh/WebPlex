namespace WebPlex.Services.Impl.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IBannedIpService : IDbService<BannedIpEntity> {
		BannedIpEntity Get(string ipAddress, bool inVisible, bool logIfNull);

		bool IsBanned(string ipAddress);

		OperationResult<BannedIpEntity> Save(string ipAddress, string reason, DateTime startDateUtc, DateTime? expireDateUtc);

		OperationResult Delete(string ipAddress, bool onlyChangeFlag);
	}
}