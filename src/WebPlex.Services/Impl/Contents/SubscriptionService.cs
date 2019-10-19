namespace WebPlex.Services.Impl.Contents {
	using System;
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Contents;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class SubscriptionService : DbServiceBase<SubscriptionEntity>, ISubscriptionService {
		public SubscriptionService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public SubscriptionEntity Get(string email, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(email))
				return null;

			var subscription = Get(s => s.Email == email, inVisible, logIfNull);

			return subscription;
		}

		public IList<SubscriptionEntity> GetAllConfirmationExpired() {
			return GetAll(s => s.SubscribDateUtc <= DateTime.UtcNow.AddDays(3) && s.Status == SubscriptionStatus.ConfirmationSent, false);
		}

		public OperationResult<SubscriptionEntity> Save(string email, SubscriptionStatus status, DateTime subscribDateUtc, DateTime? confirmDateUtc, DateTime? cancelDateUtc) {
			var result = EngineContext.Current.Resolve<OperationResult<SubscriptionEntity>>();

			var subscription = Get(email, true, false);

			if (subscription == null) {
				subscription = new SubscriptionEntity {
						IsEnabled = true,
						Email = email
				};
			}

			subscription.Status = status;
			subscription.SubscribDateUtc = subscribDateUtc;
			subscription.ConfirmDateUtc = confirmDateUtc;
			subscription.CancelDateUtc = cancelDateUtc;

			result += Save(subscription, false);

			return result.With(subscription);
		}

		public OperationResult Delete(string email, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var subscription = Get(email, true, true);

			if (subscription == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(subscription, onlyChangeFlag);

			return result;
		}

		protected override SubscriptionEntity GetDatabaseVersion(SubscriptionEntity subscription) {
			return Get(subscription.Email, true, false);
		}
	}
}