namespace WebPlex.MvcApplication.Controllers {
	using System.Web.Mvc;

	using WebPlex.MvcApplication.Models.Home;
	using WebPlex.Resources;
	using WebPlex.Services.Utils;
	using WebPlex.Web.Mvc;

	public partial class HomeController : PlexControllerBase {
		private readonly IMessageService _messageService;

		public HomeController(IMessageService messageService) {
			_messageService = messageService;
		}

		public virtual RedirectToRouteResult RedirectToIndex() {
			return RedirectToActionPermanent(T4Routes.Home.Index());
		}

		[HttpGet]
		public virtual ActionResult Index() {
			return View();
		}

		[HttpGet]
		public virtual ActionResult About() {
			return View();
		}

		[HttpGet]
		public virtual ActionResult Contact() {
			return View(new ContactModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult Contact(ContactModel model, string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (!ModelState.IsValid)
				return View(model);

			if (_messageService.SendContactMessage(model.Email, model.Name, model.Message)) {
				SuccessAlert(Messages.Contact_SendMessageSucceded);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			ErrorAlert(Messages.Contact_SendMessageFailed);

			return View(model);
		}
	}
}