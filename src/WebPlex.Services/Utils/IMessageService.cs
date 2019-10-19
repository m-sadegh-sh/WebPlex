namespace WebPlex.Services.Utils {
	using System.Net.Mail;

	using WebPlex.Core.Domain.Entities.Workflow;

	public interface IMessageService {
		bool SendEmail(MailMessage message, EmailAccountEntity emailAccount);
		bool SendQueuedMail(QueuedMailEntity queuedMail);
		bool SendContactMessage(string name, string email, string message);
	}
}