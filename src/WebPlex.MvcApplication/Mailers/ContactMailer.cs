namespace WebPlex.MvcApplication.Mailers {
	using System.Net.Mail;

	using WebPlex.Core.Engine;
	using WebPlex.MvcApplication.Models.Home;
	using WebPlex.Services.Impl.Workflow;

	public class ContactMailer : CustomMailerBase {
		public virtual MailMessage PrepareUserMessage(ContactModel model) {
			var emailAccountService = EngineContext.Current.Resolve<IEmailAccountService>();

			var noReply = emailAccountService.GetNoReply();
			var contact = emailAccountService.GetContact();

			var from = new MailAddress(noReply.Email, noReply.Name);
			var to = new MailAddress(contact.Email, contact.Name);

			var message = new MailMessage(from, to) {
					Subject = string.Format("پیام جدید از {0} ({1})", model.Name, model.Email),
					IsBodyHtml = true
			};

			ViewData.Model = model;

			//TODO
			PopulateBody(message, "PrepareUserMessage");

			return message;
		}
	}
}