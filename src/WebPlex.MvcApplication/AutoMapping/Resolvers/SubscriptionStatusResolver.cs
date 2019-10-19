namespace WebPlex.MvcApplication.AutoMapping.Resolvers {
	using AutoMapper;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Contents;
	using WebPlex.Resources;

	public sealed class SubscriptionStatusResolver : IValueResolver {
		public ResolutionResult Resolve(ResolutionResult source) {
			var status = (SubscriptionStatus) source.Value;

			string value;

			switch (status) {
				case SubscriptionStatus.Pending:
					value = Members.SubscriptionStatus_Pending;
					break;

				case SubscriptionStatus.ConfirmationSent:
					value = Members.SubscriptionStatus_ConfirmationSent;
					break;

				case SubscriptionStatus.Confirmed:
					value = Members.SubscriptionStatus_Confirmed;
					break;

				case SubscriptionStatus.Cancelled:
					value = Members.SubscriptionStatus_Cancelled;
					break;

				default:
					throw new NotSupportedEnumException(status);
			}

			return source.New(value);
		}
	}
}