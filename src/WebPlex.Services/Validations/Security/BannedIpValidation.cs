namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class BannedIpValidation : EntityValidationBase<BannedIpEntity> {
		public BannedIpValidation() {
			Define(bi => bi.IpAdrress).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.BannedIpEntity_IpAdrress)).And.IsIp().WithMessage(ValidationHelpers.InvalidIpAddress(Members.BannedIpEntity_IpAdrress));

			Define(bi => bi.Reason).MaxLength();

			Define(bi => bi.StartDateUtc);

			Define(bi => bi.ExpireDateUtc);

			ValidateInstance.By((bannedIp, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IBannedIpService>();

				                    if (service.Get(bannedIp.IpAdrress, true, false).IsDuplicate(bannedIp)) {
					                    context.AddInvalid<BannedIpEntity, string>(ValidationHelpers.DuplicateValue(Members.BannedIpEntity_IpAdrress, bannedIp.IpAdrress), bi => bi.IpAdrress);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}