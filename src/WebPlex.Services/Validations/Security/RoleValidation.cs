namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class RoleValidation : EntityValidationBase<RoleEntity> {
		public RoleValidation() {
			Define(r => r.Name).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.RoleEntity_Name));

			Define(r => r.InternalKey);

			Define(r => r.Permissions);

			Define(r => r.Groups);

			Define(r => r.Users);

			ValidateInstance.By((role, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IRoleService>();

				                    if (service.Get(role.Name, true, false).IsDuplicate(role)) {
					                    context.AddInvalid<RoleEntity, string>(ValidationHelpers.DuplicateValue(Members.RoleEntity_Name, role.Name), r => r.Name);

					                    isValid = false;
				                    }

				                    if (service.Get(role.InternalKey, true, false).IsDuplicate(role)) {
					                    context.AddInvalid<RoleEntity, Constant>(ValidationHelpers.DuplicateValue(Members.RoleEntity_InternalKey, role.InternalKey), r => r.InternalKey);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}