namespace WebPlex.Services.Validations.Workflow {
	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class QueuedMailValidation : EntityValidationBase<QueuedMailEntity> {
		public QueuedMailValidation() {
			Define(qm => qm.FromEmail).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.QueuedMailEntity_FromEmail)).And.IsEmail().WithMessage(ValidationHelpers.InvalidEmail(Members.QueuedMailEntity_FromEmail));

			Define(qm => qm.FromName);

			Define(qm => qm.ToEmail).NotNullableAndNotEmpty().WithMessage(ValidationHelpers.Required(Members.QueuedMailEntity_ToEmail)).And.IsEmail().WithMessage(ValidationHelpers.InvalidEmail(Members.QueuedMailEntity_ToEmail));

			Define(qm => qm.ToName);

			Define(qm => qm.Cc).Satisfy(e => e.All(PatternValidator.IsValidEmail)).WithMessage(ValidationHelpers.InvalidEmail(Members.QueuedMailEntity_Cc));

			Define(qm => qm.Bcc).Satisfy(e => e.All(PatternValidator.IsValidEmail)).WithMessage(ValidationHelpers.InvalidEmail(Members.QueuedMailEntity_Bcc));

			Define(qm => qm.Subject);

			Define(qm => qm.Body).MaxLength();

			Define(qm => qm.Importance);

			Define(qm => qm.SendTries);

			Define(qm => qm.SentDateUtc);
		}
	}
}