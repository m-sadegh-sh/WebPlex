namespace WebPlex.MvcApplication.Areas.Admin.Controllers {
	using System.Web.Mvc;

	using WebMatrix.WebData;

	using WebPlex.Core.Configuration;
	using WebPlex.Data.Knowns.Security;
	using WebPlex.MvcApplication.Controllers;
	using WebPlex.Resources;
	using WebPlex.Services.Impl.Configuration;
	using WebPlex.Services.Impl.Security;
	using WebPlex.Services.Security;
	using WebPlex.Web.Mvc;
	using WebPlex.Web.Security;

	[AdminRequired]
	[RequireHttps]
	public partial class ConfigurationController : PlexControllerBase {
		private readonly PermissionInstaller _permissionInstaller;
		private readonly IUserService _userService;
		private readonly IAuthorizationService _authorizationService;
		private readonly IApplicationSettingsService _applicationSettingsService;

		public ConfigurationController(PermissionInstaller permissionInstaller, IUserService userService, IAuthorizationService authorizationService, IApplicationSettingsService applicationSettingsService) {
			_permissionInstaller = permissionInstaller;
			_userService = userService;
			_authorizationService = authorizationService;
			_applicationSettingsService = applicationSettingsService;
		}

		[HttpGet]
		[Transactional]
		public virtual ActionResult EnsureDefaultUser(string returnUrl) {
			var config = BootstrapConfig.Current;

			_permissionInstaller.EnsureGroupsInstalled();
			_permissionInstaller.EnsurePermissionsInstalled();

			if (!WebSecurity.UserExists(config.Email))
				PlexSecurity.Provider.CreateUserAndAccount(config.Email, config.Password, false);

			var user = _userService.Get(config.Email, false, false);

			_authorizationService.AddRoleToUser(user, Roles.Users);
			_authorizationService.AddRoleToUser(user, Roles.Administrators);

			SuccessAlert(Messages.Configuration_DefaultUserSucceeded, true);

			return RedirectToLocal(returnUrl, T4Routes.Home.Index());
		}

		[HttpGet]
		[Transactional]
		public virtual ActionResult EnsureDefaultSettings(string returnUrl) {
			Application.DefaultTimeZoneId = "Iran Standard Time";
			Application.AllowUsersToSetTimeZone = false;
			Application.DefaultLanguage = "fa-IR";
			Application.AllowUsersToSetLanguage = false;
			Application.TitleSeparator = " - ";
			Application.IsClosed = false;
			Application.CloseReason = "";
			_applicationSettingsService.SaveChanges();

			SuccessAlert(Messages.Configuration_DefaultSettingsSucceeded, true);

			return RedirectToLocal(returnUrl, T4Routes.Home.Index());
		}
	}
}