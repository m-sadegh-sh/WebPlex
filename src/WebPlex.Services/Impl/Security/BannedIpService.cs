namespace WebPlex.Services.Impl.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class BannedIpService : DbServiceBase<BannedIpEntity>, IBannedIpService {
		public BannedIpService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public BannedIpEntity Get(string ipAddress, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(ipAddress))
				return null;

			var bannedIp = Get(bi => bi.IpAdrress == ipAddress, inVisible, logIfNull);

			return bannedIp;
		}

		public bool IsBanned(string ipAddress) {
			if (string.IsNullOrEmpty(ipAddress))
				return false;

			var bannedIp = Get(ipAddress, false, false);

			if (bannedIp == null)
				return false;

			if (bannedIp.ExpireDateUtc < DateTime.UtcNow)
				return false;

			return true;
		}

		public OperationResult<BannedIpEntity> Save(string ipAddress, string reason, DateTime startDateUtc, DateTime? expireDateUtc) {
			var result = EngineContext.Current.Resolve<OperationResult<BannedIpEntity>>();

			var bannedIp = Get(ipAddress, true, false);

			if (bannedIp == null) {
				bannedIp = new BannedIpEntity {
						IsEnabled = true,
						IpAdrress = ipAddress
				};
			}

			bannedIp.Reason = reason;
			bannedIp.StartDateUtc = startDateUtc;
			bannedIp.ExpireDateUtc = expireDateUtc;

			result += Save(bannedIp, false);

			return result.With(bannedIp);
		}

		public OperationResult Delete(string ipAddress, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var bannedIp = Get(ipAddress, true, true);

			if (bannedIp == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(bannedIp, onlyChangeFlag);

			return result;
		}

		protected override BannedIpEntity GetDatabaseVersion(BannedIpEntity bannedIp) {
			return Get(bannedIp.IpAdrress, true, false);
		}
	}
}