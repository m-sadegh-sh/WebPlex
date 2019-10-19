namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Infrastructure;

	public sealed class PermissionGroupValidation : EntityValidationBase<PermissionGroupEntity> {
		public PermissionGroupValidation() {
			Define(pg => pg.Name).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.PermissionGroupEntity_Name));

			Define(pg => pg.InternalKey);

			Define(pg => pg.Permissions);

			Define(pg => pg.Roles);

			ValidateInstance.By((group, context) => {
				                    var isValid = true;

				                    var service = EngineContext.Current.Resolve<IPermissionGroupService>();

				                    if (service.Get(group.Name, true, false).IsDuplicate(group)) {
					                    context.AddInvalid<PermissionGroupEntity, string>(ValidationHelpers.DuplicateValue(Members.PermissionGroupEntity_Name, group.Name), pg => pg.Name);

					                    isValid = false;
				                    }

				                    if (service.Get(group.InternalKey, true, false).IsDuplicate(group)) {
					                    context.AddInvalid<PermissionGroupEntity, Constant>(ValidationHelpers.DuplicateValue(Members.PermissionGroupEntity_InternalKey, group.InternalKey), pg => pg.InternalKey);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}