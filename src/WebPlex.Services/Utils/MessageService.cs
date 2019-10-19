namespace WebPlex.Services.Utils {
	using System;
	using System.Net;
	using System.Net.Mail;

	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Impl.Workflow;

	public sealed class MessageService : IMessageService {
		private readonly IEmailAccountService _emailAccountService;
		private readonly ILogService _logService;

		public MessageService(IEmailAccountService emailAccountService, ILogService logService) {
			_emailAccountService = emailAccountService;
			_logService = logService;
		}

		public bool SendEmail(MailMessage message, EmailAccountEntity emailAccount) {
			try {
				var smtpClient = new SmtpClient {
						EnableSsl = emailAccount.SslEnabled,
						Host = emailAccount.Host,
						Port = emailAccount.Port,
						UseDefaultCredentials = emailAccount.UseDefaultCredentials,
						Credentials = new NetworkCredential(emailAccount.UserName, emailAccount.Password),
				};

				smtpClient.Send(message);

				_logService.Information("A new message was sent.");

				return true;
			} catch (Exception exception) {
				_logService.Error("An error occured when sending a message", exception);

				return false;
			}
		}

		public bool SendQueuedMail(QueuedMailEntity queuedMail) {
			var noReply = _emailAccountService.GetNoReply();

			var from = new MailAddress(queuedMail.FromEmail, queuedMail.FromName);
			var to = new MailAddress(queuedMail.ToEmail, queuedMail.ToName);

			var message = new MailMessage(from, to) {
					Subject = queuedMail.Subject,
					Body = queuedMail.Body,
					IsBodyHtml = queuedMail.IsBodyHtml
			};

			queuedMail.Cc.ForEach(message.CC.Add);

			queuedMail.Bcc.ForEach(message.Bcc.Add);

			return SendEmail(message, noReply);
		}

		public bool SendContactMessage(string name, string email, string message) {
			var contactForm = EngineContext.Current.Resolve<ContactFormSettings>();
			var noReply = _emailAccountService.GetNoReply();
			var contact = _emailAccountService.GetContact();

			var from = new MailAddress(email, name);
			var to = new MailAddress(contact.Email, contactForm.RecipientName);

			var mailMessage = new MailMessage(from, to) {
					Subject = contactForm.Subject,
					Body = message,
					IsBodyHtml = false
			};

			return SendEmail(mailMessage, noReply);
		}
	}
}