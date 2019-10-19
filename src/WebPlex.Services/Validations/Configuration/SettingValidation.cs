namespace WebPlex.Services.Validations.Configuration {
	using WebPlex.Core.Domain.Entities.Configuration;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Configuration;
	using WebPlex.Services.Infrastructure;

	public sealed class SettingValidation : EntityValidationBase<SettingEntity> {
		public SettingValidation() {
			Define(s => s.Key).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.SettingEntity_Key));

			Define(s => s.Value).MaxLength();

			ValidateInstance.By((setting, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<ISettingService>();

				                    if (service.Get(setting.Key, true, false).IsDuplicate(setting)) {
					                    context.AddInvalid<SettingEntity, string>(ValidationHelpers.DuplicateValue(Members.SettingEntity_Key, setting.Key), s => s.Key);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}