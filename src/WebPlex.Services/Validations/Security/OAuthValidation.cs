namespace WebPlex.Services.Validations.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class OAuthValidation : EntityValidationBase<OAuthEntity> {
		public OAuthValidation() {
			Define(oa => oa.ProviderKey).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.OAuthEntity_ProviderKey));

			Define(oa => oa.UserKey).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.OAuthEntity_UserKey));

			Define(oa => oa.User);

			ValidateInstance.By((oauth, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IOAuthService>();

				                    if (service.Get(oauth.ProviderKey, oauth.UserKey, true, false).IsDuplicate(oauth)) {
					                    context.AddInvalid(ValidationHelpers.DuplicateValues(Tuple.Create(Members.OAuthEntity_ProviderKey, (object) oauth.ProviderKey), Tuple.Create(Members.OAuthEntity_UserKey, (object) oauth.UserKey)));

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}