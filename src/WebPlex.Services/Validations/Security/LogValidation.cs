namespace WebPlex.Services.Validations.Security {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class LogValidation : EntityValidationBase<LogEntity> {
		public LogValidation() {
			Define(l => l.Severity);

			Define(l => l.LogDateUtc);

			Define(l => l.FullMessage).MaxLength();

			Define(l => l.StackTrace).MaxLength();

			Define(l => l.RequestUrl);

			Define(l => l.ReferrerUrl);

			Define(l => l.Invoker);

			Define(l => l.InvokerIp);
		}
	}
}