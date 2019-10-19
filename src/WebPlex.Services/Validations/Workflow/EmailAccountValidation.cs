namespace WebPlex.Services.Validations.Workflow {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Core.Engine;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Workflow;
	using WebPlex.Services.Infrastructure;

	public sealed class EmailAccountValidation : EntityValidationBase<EmailAccountEntity> {
		public EmailAccountValidation() {
			Define(ea => ea.Email).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.EmailAccountEntity_Email)).And.IsEmail().WithMessage(ValidationHelpers.InvalidEmail(Members.EmailAccountEntity_Email));

			Define(ea => ea.InternalKey);

			Define(ea => ea.Name);

			Define(ea => ea.UserName);

			Define(ea => ea.Password);

			Define(ea => ea.Host).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.EmailAccountEntity_Host));

			Define(ea => ea.Port);

			Define(ea => ea.SslEnabled);

			Define(ea => ea.UseDefaultCredentials);

			Define(ea => ea.IsDefault);

			ValidateInstance.By((emailAccount, context) => {
				                    var isValid = true;

				                    if (emailAccount.UseDefaultCredentials) {
					                    emailAccount.UserName = null;
					                    emailAccount.Password = null;
				                    } else {
					                    if (string.IsNullOrEmpty(emailAccount.UserName)) {
						                    context.AddInvalid<EmailAccountEntity, string>(ValidationHelpers.Required(Members.EmailAccountEntity_UserName), ea => ea.UserName);

						                    isValid = false;
					                    }

					                    if (string.IsNullOrEmpty(emailAccount.Password)) {
						                    context.AddInvalid<EmailAccountEntity, string>(ValidationHelpers.Required(Members.EmailAccountEntity_Password), ea => ea.Password);

						                    isValid = false;
					                    }
				                    }

				                    var service = EngineContext.Current.Resolve<IEmailAccountService>();

				                    if (service.Get(emailAccount.Email, true, false).IsDuplicate(emailAccount)) {
					                    context.AddInvalid<EmailAccountEntity, string>(ValidationHelpers.DuplicateValue(Members.EmailAccountEntity_Email, emailAccount.Email), ea => ea.Email);

					                    isValid = false;
				                    }

				                    if (service.Get(emailAccount.InternalKey, true, false).IsDuplicate(emailAccount)) {
					                    context.AddInvalid<EmailAccountEntity, Constant>(ValidationHelpers.DuplicateValue(Members.EmailAccountEntity_InternalKey, emailAccount.InternalKey), ea => ea.InternalKey);

					                    isValid = false;
				                    }

				                    return isValid;
			                    });
		}
	}
}