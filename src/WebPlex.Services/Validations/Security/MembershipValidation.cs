namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;
	using WebPlex.Services.Validations.Extensions;

	public sealed class MembershipValidation : EntityValidationBase<MembershipEntity> {
		public MembershipValidation() {
			Define(m => m.User).NotNullable().WithMessage(ValidationHelpers.Required(Members.MembershipEntity_User));

			Define(m => m.ConfirmationToken);

			Define(m => m.Password).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.MembershipEntity_Password));

			Define(m => m.CreateDateUtc);

			Define(m => m.LastActivityDateUtc);

			Define(m => m.LastLoginDateUtc);

			Define(m => m.LastPasswordChangeDateUtc);

			Define(m => m.LastPasswordFailureDateUtc);

			Define(m => m.PasswordFailuresSinceLastSuccess);

			Define(m => m.PasswordVerificationToken);

			Define(m => m.PasswordVerificationTokenExpirationDateUtc);

			Define(m => m.PasswordResetRequested);

			Define(m => m.LastLockoutDateUtc);

			Define(m => m.IsLocked);

			Define(m => m.LastIpAddress);

			Define(m => m.AdminComment).MaxLength();

			ValidateInstance.By((membership, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IMembershipService>();

				                    if (service.Get(membership.User, true, false).IsDuplicate(membership)) {
					                    context.AddInvalid<MembershipEntity, UserEntity>(ValidationHelpers.DuplicateValue(Members.MembershipEntity_User, membership.User), m => m.User);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}