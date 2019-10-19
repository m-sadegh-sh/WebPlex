namespace WebPlex.Web {
	using System.Globalization;

	using WebMatrix.WebData;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Impl.Security;

	public sealed class WebWorkContext : IWorkContext {
		private readonly IUserService _userService;
		private readonly IUserAttributeService _userAttributeService;
		private UserEntity _currentUser;
		private CultureInfo _currentCulture;

		public WebWorkContext(IUserService userService, IUserAttributeService userAttributeService) {
			_userService = userService;
			_userAttributeService = userAttributeService;
		}

		public UserEntity CurrentUser {
			get {
				if (_currentUser != null)
					return _currentUser;

				_currentUser = _userService.Get(WebSecurity.CurrentUserName, false, true);

				return _currentUser;
			}
		}

		public CultureInfo CurrentCulture {
			get {
				if (_currentCulture != null)
					return _currentCulture;

				if (CurrentUser != null) {
					var cultureCode = _userAttributeService.GetValue(CurrentUser, UserAttribute.CultureCode, "", false, false);

					_currentCulture = CultureInfo.CreateSpecificCulture(cultureCode);
				}

				return _currentCulture;
			}
		}
	}
}