namespace WebPlex.Services.Validations.Contents {
	using WebPlex.Core.Domain.Entities.Contents;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Contents;
	using WebPlex.Services.Infrastructure;

	public sealed class SubscriptionValidation : EntityValidationBase<SubscriptionEntity> {
		public SubscriptionValidation() {
			Define(s => s.Email).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.SubscriptionEntity_Email)).And.IsEmail().WithMessage(ValidationHelpers.InvalidEmail(Members.SubscriptionEntity_Email));

			Define(s => s.Status);

			Define(s => s.SubscribDateUtc);

			Define(s => s.ConfirmDateUtc);

			Define(s => s.CancelDateUtc);

			ValidateInstance.By((subscription, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<ISubscriptionService>();

				                    if (service.Get(subscription.Email, true, false).IsDuplicate(subscription)) {
					                    context.AddInvalid<SubscriptionEntity, string>(ValidationHelpers.DuplicateValue(Members.SubscriptionEntity_Email, subscription.Email), s => s.Email);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}