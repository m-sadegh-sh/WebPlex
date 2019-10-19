namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class PermissionValidation : EntityValidationBase<PermissionEntity> {
		public PermissionValidation() {
			Define(p => p.Name).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.PermissionEntity_Name));

			Define(p => p.InternalKey);

			ValidateInstance.By((permission, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IPermissionService>();

				                    if (service.Get(permission.Name, true, false).IsDuplicate(permission)) {
					                    context.AddInvalid<PermissionEntity, string>(ValidationHelpers.DuplicateValue(Members.PermissionEntity_Name, permission.Name), p => p.Name);

					                    isValid = false;
				                    }

				                    if (service.Get(permission.InternalKey, true, false).IsDuplicate(permission)) {
					                    context.AddInvalid<PermissionEntity, Constant>(ValidationHelpers.DuplicateValue(Members.PermissionEntity_InternalKey, permission.InternalKey), p => p.InternalKey);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}