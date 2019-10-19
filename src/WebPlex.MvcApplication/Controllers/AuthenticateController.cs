namespace WebPlex.MvcApplication.Controllers {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Security;

	using Microsoft.Web.WebPages.OAuth;

	using WebMatrix.WebData;

	using WebPlex.MvcApplication.Models.Authenticate;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Web.Mvc;
	using WebPlex.Web.Security;

	[RequireHttps]
	public partial class AuthenticateController : PlexControllerBase {
		private readonly IUserService _userService;

		public AuthenticateController(IUserService userService) {
			_userService = userService;
		}

		[HttpGet]
		public virtual ActionResult SignIn(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			return View(new SignInModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult SignIn(SignInModel model, string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (!ModelState.IsValid)
				return View(model);

			if (WebSecurity.Login(model.Email, model.Password, model.RememberMe)) {
				SuccessAlert(Messages.Membership_SignInSucceded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			ModelState.AddModelError("", Messages.Membership_InvalidEmailOrPassword);

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual ActionResult ExternalSignIn(string providerKey, string returnUrl) {
			return new ExternalLoginResult(providerKey, Url.Action(T4Routes.Authenticate.ExternalSignInCallback(returnUrl)));
		}

		[HttpGet]
		[Transactional]
		public virtual ActionResult ExternalSignInCallback(string returnUrl) {
			var result = OAuthWebSecurity.VerifyAuthentication(Url.Action(T4Routes.Authenticate.ExternalSignInCallback(returnUrl)));

			if (!result.IsSuccessful) {
				ErrorAlert(Messages.Membership_ExternalSignInFailed, true);

				return RedirectToAction(T4Routes.Authenticate.SignIn(returnUrl));
			}

			if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, false)) {
				SuccessAlert(Messages.Membership_ExternalSignInSucceeded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			var email = WebSecurity.IsAuthenticated ? WebSecurity.CurrentUserName : result.UserName;

			try {
				OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, email);
				OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, false);

				SuccessAlert(Messages.Membership_ExternalSignInSucceeded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			} catch (MembershipCreateUserException) {
				ErrorAlert(Messages.Membership_ExternalSignInFailed);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}
		}

		[HttpGet]
		public virtual ActionResult SignOut(string returnUrl) {
			if (!Request.IsAuthenticated)
				throw new HttpException((int) HttpStatusCode.Forbidden, null);

			WebSecurity.Logout();

			SuccessAlert(Messages.Membership_SignOutSucceded, true);

			return RedirectToLocal(returnUrl, T4Routes.Home.Index());
		}

		[HttpGet]
		public virtual ActionResult SignUp(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			return View(new SignUpModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult SignUp(SignUpModel model, string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (!ModelState.IsValid)
				return View(model);

			try {
				WebSecurity.CreateUserAndAccount(model.Email, model.Password, null, true);
				WebSecurity.Login(model.Email, model.Password, false);

				SuccessAlert(Messages.Membership_SignUpSucceded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			} catch (MembershipCreateUserException e) {
				ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));

				return View(model);
			}
		}

		[HttpGet]
		public virtual ActionResult ResetPassword(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (!OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId)) {
				ErrorAlert(Messages.Membership_LocalAccountRequired, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			return View(new ResetPasswordModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult ResetPassword(ResetPasswordModel model, string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (!OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId)) {
				ErrorAlert(Messages.Membership_LocalAccountRequired, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			if (!ModelState.IsValid)
				return View(model);

			try {
				PlexSecurity.Provider.ResetPassword(model.Email);

				SuccessAlert(Messages.Membership_PasswordResetSucceded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			} catch (MembershipCreateUserException e) {
				ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));

				return View(model);
			}
		}

		[HttpGet]
		public virtual ActionResult SetOrChangePassword(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId))
				return View(Views.ChangePassword, new ChangePasswordModel());

			return View(Views.SetPassword, new SetPasswordModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult SetPassword(SetPasswordModel model, string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId)) {
				ErrorAlert(Messages.Membership_PasswordAlreadySet, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			if (!ModelState.IsValid)
				return View(model);

			try {
				WebSecurity.CreateAccount(WebSecurity.CurrentUserName, model.NewPassword);

				SuccessAlert(Messages.Membership_PasswordSetSucceded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			} catch (MembershipCreateUserException e) {
				ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));

				return View(model);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult ChangePassword(ChangePasswordModel model, string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			if (!OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId)) {
				ErrorAlert(Messages.Membership_LocalAccountRequired, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			}

			if (!ModelState.IsValid)
				return View(model);

			try {
				WebSecurity.ChangePassword(WebSecurity.CurrentUserName, model.CurrentPassword, model.NewPassword);

				SuccessAlert(Messages.Membership_PasswordChangeSucceded, true);

				return RedirectToLocal(returnUrl, T4Routes.Home.Index());
			} catch (MembershipCreateUserException e) {
				ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));

				return View(model);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Transactional]
		public virtual ActionResult Disassociate(string providerKey, string userKey, string returnUrl) {
			var ownerAccount = OAuthWebSecurity.GetUserName(providerKey, userKey);

			if (!string.Equals(ownerAccount, WebSecurity.CurrentUserName, StringComparison.OrdinalIgnoreCase))
				ErrorAlert(Messages.Membership_RelatedProviderRequired, true);
			else {
				var hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId);
				var hasAnyOAuthAccount = OAuthWebSecurity.GetAccountsFromUserName(WebSecurity.CurrentUserName).Any();

				if (!hasLocalAccount || !hasAnyOAuthAccount)
					ErrorAlert(Messages.Membership_AccountNotFound, true);
				else {
					OAuthWebSecurity.DeleteAccount(providerKey, userKey);

					SuccessAlert(Messages.Membership_AccountDeleteSucceded, true);
				}
			}

			return RedirectToLocal(returnUrl, T4Routes.Home.Index());
		}

		[ChildActionOnly]
		public virtual ActionResult ExternalSignIns(string returnUrl) {
			ViewBag.ReturnUrl = returnUrl;

			return PartialView(OAuthWebSecurity.RegisteredClientData);
		}

		[ChildActionOnly]
		public virtual ActionResult RemoveExternalSignIns() {
			ViewBag.ShowRemoveButton = OAuthWebSecurity.HasLocalAccount(WebSecurity.CurrentUserId);

			var accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);

			var externalLogins = new List<ExternalLoginModel>();

			foreach (var account in accounts) {
				var clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

				externalLogins.Add(new ExternalLoginModel {
						Provider = account.Provider,
						ProviderDisplayName = clientData.DisplayName,
						ProviderUserKey = account.ProviderUserId,
				});
			}

			return PartialView(externalLogins);
		}

		private static string ErrorCodeToString(MembershipCreateStatus status) {
			switch (status) {
				case MembershipCreateStatus.InvalidEmail:
					return Messages.Membership_InvalidEmail;

				case MembershipCreateStatus.InvalidPassword:
					return Messages.Membership_InvalidOldPassword;

				default:
					return Messages.Membership_InvalidEmailOrPassword;
			}
		}
	}
}