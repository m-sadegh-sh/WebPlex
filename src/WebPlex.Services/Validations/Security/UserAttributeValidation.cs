namespace WebPlex.Services.Validations.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;
	using WebPlex.Services.Validations.Extensions;

	public sealed class UserAttributeValidation : AttributeEntityValidationBase<UserAttributeEntity, UserAttribute> {
		public UserAttributeValidation() {
			Define(ua => ua.User).NotNullable().WithMessage(ValidationHelpers.Required(Members.UserAttributeEntity_User));

			ValidateInstance.By((userAttribute, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IUserAttributeService>();

				                    if (DuplicationExtentions.IsDuplicate(service.Get(userAttribute.User, userAttribute.Key, true, false), userAttribute)) {
					                    context.AddInvalid(ValidationHelpers.DuplicateValues(Tuple.Create(Members.UserAttributeEntity_User, (object) userAttribute.User), Tuple.Create(Members.AttributeEntityBase_Key, (object) userAttribute.Key)));

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}