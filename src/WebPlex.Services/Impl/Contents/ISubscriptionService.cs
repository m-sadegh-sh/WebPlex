namespace WebPlex.Services.Impl.Contents {
	using System;
	using System.Collections.Generic;

	using WebPlex.Core.Domain.Entities.Contents;
	using WebPlex.Services.Infrastructure;

	public interface ISubscriptionService : IDbService<SubscriptionEntity> {
		SubscriptionEntity Get(string email, bool inVisible, bool logIfNull);

		IList<SubscriptionEntity> GetAllConfirmationExpired();

		OperationResult<SubscriptionEntity> Save(string email, SubscriptionStatus status, DateTime subscribDateUtc, DateTime? confirmDateUtc, DateTime? cancelDateUtc);

		OperationResult Delete(string email, bool onlyChangeFlag);
	}
}