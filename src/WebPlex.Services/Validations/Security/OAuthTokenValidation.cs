namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class OAuthTokenValidation : EntityValidationBase<OAuthTokenEntity> {
		public OAuthTokenValidation() {
			Define(oat => oat.Token).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.OAuthTokenEntity_Token));

			Define(oat => oat.Token).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.OAuthTokenEntity_Secret));

			ValidateInstance.By((oauthToken, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IOAuthTokenService>();

				                    if (service.Get(oauthToken.Token, true, false).IsDuplicate(oauthToken)) {
					                    context.AddInvalid<OAuthTokenEntity, Constant>(ValidationHelpers.DuplicateValue(Members.OAuthTokenEntity_Token, oauthToken.Token), oat => oat.Token);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}