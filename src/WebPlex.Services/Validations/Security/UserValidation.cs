namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class UserValidation : EntityValidationBase<UserEntity> {
		public UserValidation() {
			Define(u => u.Email).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.UserEntity_Email)).And.IsEmail().WithMessage(ValidationHelpers.InvalidEmail(Members.UserEntity_Email));

			Define(u => u.OAuths);

			Define(u => u.Roles);

			ValidateInstance.By((user, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IUserService>();

				                    if (service.Get(user.Email, true, false).IsDuplicate(user)) {
					                    context.AddInvalid<UserEntity, string>(ValidationHelpers.DuplicateValue(Members.UserEntity_Email, user.Email), u => u.Email);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}