namespace WebPlex.Web.Security {
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Security.Cryptography;
	using System.Web;
	using System.Web.Helpers;
	using System.Web.Security;

	using CuttingEdge.Conditions;

	using Utilities.DataTypes.ExtensionMethods;

	using WebMatrix.WebData;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Services.Impl.Security;

	public sealed class PlexMembershipProvider : ExtendedMembershipProvider {
		private const int TOKEN_SIZE_IN_BYTES = 16;

		private readonly IUserService _userService;
		private readonly IOAuthService _oauthService;
		private readonly IOAuthTokenService _oauthTokenService;
		private readonly IMembershipService _membershipService;

		public override bool EnablePasswordRetrieval {
			get { return false; }
		}

		public override bool EnablePasswordReset {
			get { return true; }
		}

		public override bool RequiresQuestionAndAnswer {
			get { return false; }
		}

		public override string ApplicationName {
			get { throw new NotSupportedException(); }
			set { throw new NotSupportedException(); }
		}

		public override int MaxInvalidPasswordAttempts {
			get { return int.MaxValue; }
		}

		public override int PasswordAttemptWindow {
			get { return int.MaxValue; }
		}

		public override bool RequiresUniqueEmail {
			get { return true; }
		}

		public override MembershipPasswordFormat PasswordFormat {
			get { return MembershipPasswordFormat.Hashed; }
		}

		public override int MinRequiredPasswordLength {
			get { return 6; }
		}

		public override int MinRequiredNonAlphanumericCharacters {
			get { return 0; }
		}

		public override string PasswordStrengthRegularExpression {
			get { return null; }
		}

		public new event MembershipValidatePasswordEventHandler ValidatingPassword {
			add { throw new NotSupportedException(); }
			remove { throw new NotSupportedException(); }
		}

		public PlexMembershipProvider() {
			_userService = EngineContext.Current.Resolve<IUserService>();
			_oauthService = EngineContext.Current.Resolve<IOAuthService>();
			_oauthTokenService = EngineContext.Current.Resolve<IOAuthTokenService>();
			_membershipService = EngineContext.Current.Resolve<IMembershipService>();
		}

		public PlexMembershipProvider(IUserService userService, IOAuthService oauthService, IOAuthTokenService oauthTokenService, IMembershipService membershipService) {
			_userService = userService;
			_oauthService = oauthService;
			_oauthTokenService = oauthTokenService;
			_membershipService = membershipService;
		}

		public PlexMembershipUser CreateUser(string email, out MembershipCreateStatus status) {
			var user = _userService.Get(email, false, false);

			if (user != null) {
				status = MembershipCreateStatus.DuplicateEmail;
				return null;
			}

			var userResult = _userService.Save(email);

			if (userResult.ContainsError) {
				status = MembershipCreateStatus.InvalidEmail;
				return null;
			}

			user = userResult.Value;
			status = MembershipCreateStatus.Success;

			return user;
		}

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
			throw new NotSupportedException();
		}

		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
			throw new NotSupportedException();
		}

		public override string GetPassword(string email, string answer) {
			throw new NotSupportedException();
		}

		public override bool ChangePassword(string email, string oldPassword, string newPassword) {
			Condition.Requires(email).IsNotNullOrEmpty();
			Condition.Requires(oldPassword).IsNotNullOrEmpty();
			Condition.Requires(newPassword).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				throw new MembershipCreateUserException(MembershipCreateStatus.InvalidEmail);

			if (CheckPassword(membership, oldPassword))
				throw new MembershipCreateUserException(MembershipCreateStatus.InvalidPassword);

			membership.Password = Crypto.HashPassword(newPassword);
			membership.LastPasswordChangeDateUtc = DateTime.UtcNow;

			_membershipService.Save(membership, false);

			return true;
		}

		public string ResetPassword(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				throw new MembershipCreateUserException(MembershipCreateStatus.InvalidEmail);

			membership.PasswordVerificationToken = GenerateToken();
			membership.PasswordVerificationTokenExpirationDateUtc = DateTime.UtcNow.AddDays(1);

			_membershipService.Save(membership, false);

			return membership.PasswordVerificationToken;
		}

		public override string ResetPassword(string email, string answer) {
			throw new NotSupportedException();
		}

		public override void UpdateUser(MembershipUser user) {
			throw new NotSupportedException();
		}

		public override bool ValidateUser(string email, string password) {
			Condition.Requires(email).IsNotNullOrEmpty();
			Condition.Requires(password).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				return false;

			if (!membership.IsConfirmed)
				return false;

			return CheckPassword(membership, password);
		}

		public override bool UnlockUser(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				throw new MembershipCreateUserException(MembershipCreateStatus.InvalidEmail);

			membership.IsLocked = false;

			_membershipService.Save(membership, false);

			return true;
		}

		public PlexMembershipUser GetUser(long userId, bool userIsOnline) {
			var user = _userService.Get(userId, false, false, true);

			if (userIsOnline && !((PlexMembershipUser) user).IsOnline)
				return null;

			return user;
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
			throw new NotSupportedException();
		}

		public override MembershipUser GetUser(string email, bool userIsOnline) {
			var user = _userService.Get(email, false, true);

			if (userIsOnline && !((PlexMembershipUser) user).IsOnline)
				return null;

			return (PlexMembershipUser) user;
		}

		public override string GetUserNameByEmail(string email) {
			throw new NotSupportedException();
		}

		public override bool DeleteUser(string email, bool deleteAllRelatedData) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var userResult = _userService.Delete(email, true);

			return !userResult.ContainsError;
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
			throw new NotSupportedException();
		}

		public override int GetNumberOfUsersOnline() {
			throw new NotSupportedException();
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
			throw new NotSupportedException();
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
			throw new NotSupportedException();
		}

		public void DeleteOAuthAccount(Constant providerKey, Constant userKey) {
			Condition.Requires(providerKey).IsNotNull();
			Condition.Requires(userKey).IsNotNull();

			_oauthService.Delete(providerKey, userKey, false);
		}

		public override void DeleteOAuthAccount(string providerKey, string userKey) {
			throw new NotSupportedException();
		}

		public override void CreateOrUpdateOAuthAccount(string providerKey, string userKey, string email) {
			Condition.Requires(providerKey).IsNotNullOrEmpty();
			Condition.Requires(userKey).IsNotNullOrEmpty();
			Condition.Requires(email).IsNotNullOrEmpty();

			var userResult = _userService.Save(email);

			if (userResult.ContainsError)
				throw new MembershipCreateUserException(MembershipCreateStatus.ProviderError);

			var user = userResult.Value;

			_oauthService.Save(providerKey, userKey, user);
		}

		public override int GetUserIdFromOAuth(string providerKey, string userKey) {
			Condition.Requires(providerKey).IsNotNull();
			Condition.Requires(userKey).IsNotNull();

			var oauth = _oauthService.Get(providerKey, userKey, false, true);

			return oauth != null ? (int) oauth.User.Id : 0;
		}

		public override string GetUserNameFromId(int id) {
			var user = _userService.Get(id, false, false, true);

			return user != null ? user.Email : null;
		}

		public override bool HasLocalAccount(int userId) {
			return _membershipService.GetCount(m => m.User.Id == userId, false) > 0;
		}

		public override string GetOAuthTokenSecret(string token) {
			Condition.Requires(token).IsNotNullOrEmpty();

			var oauthToken = _oauthTokenService.Get(token, false, true);

			return oauthToken != null ? oauthToken.Secret : null;
		}

		public override void StoreOAuthRequestToken(string requestToken, string requestTokenSecret) {
			Condition.Requires(requestToken).IsNotNullOrEmpty();
			Condition.Requires(requestTokenSecret).IsNotNullOrEmpty();

			_oauthTokenService.Save(requestToken, requestTokenSecret);
		}

		public override void ReplaceOAuthRequestTokenWithAccessToken(string requestToken, string accessToken, string accessTokenSecret) {
			Condition.Requires(requestToken).IsNotNullOrEmpty();
			Condition.Requires(accessToken).IsNotNullOrEmpty();
			Condition.Requires(accessTokenSecret).IsNotNullOrEmpty();

			_oauthTokenService.DeleteAll(oat => oat.Token == requestToken, false);
			StoreOAuthRequestToken(accessToken, accessTokenSecret);
		}

		public override void DeleteOAuthToken(string token) {
			Condition.Requires(token).IsNotNullOrEmpty();

			_oauthTokenService.DeleteAll(oat => oat.Token == token, false);
		}

		public override ICollection<OAuthAccountData> GetAccountsForUser(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var oauths = _oauthService.GetAll(email, false);

			var accounts = new Collection<OAuthAccountData>();

			oauths.ForEach(oa => accounts.Add(new OAuthAccountData(oa.ProviderKey, oa.UserKey)));

			return accounts;
		}

		public override string CreateUserAndAccount(string email, string password) {
			return CreateUserAndAccount(email, password, true, null);
		}

		public override string CreateUserAndAccount(string email, string password, bool requireConfirmationToken) {
			return CreateUserAndAccount(email, password, requireConfirmationToken, null);
		}

		public override string CreateUserAndAccount(string email, string password, IDictionary<string, object> values) {
			return CreateUserAndAccount(email, password, true, values);
		}

		public override string CreateUserAndAccount(string email, string password, bool requireConfirmationToken, IDictionary<string, object> values) {
			MembershipCreateStatus status;
			CreateUser(email, out status);

			return CreateAccount(email, password, requireConfirmationToken);
		}

		public override string CreateAccount(string email, string password, bool requireConfirmationToken) {
			Condition.Requires(email).IsNotNullOrEmpty();
			Condition.Requires(password).IsNotNullOrEmpty();

			var user = _userService.Get(email, false, true);

			var membership = _membershipService.Get(email, false, false);

			if (membership != null)
				throw new MembershipCreateUserException(MembershipCreateStatus.DuplicateEmail);

			var confirmationToken = (string) null;

			if (requireConfirmationToken)
				confirmationToken = GenerateToken();

			var membershipResult = _membershipService.Save(user, confirmationToken, !requireConfirmationToken, Crypto.HashPassword(password), DateTime.UtcNow, null);
			if (membershipResult.ContainsError)
				return null;

			membership = membershipResult.Value;

			user.Membership = membership;

			var userResult = _userService.Save(user, false);
			if (userResult.ContainsError)
				return null;

			return membership.ConfirmationToken;
		}

		public override bool ConfirmAccount(string email, string confirmationToken) {
			Condition.Requires(email).IsNotNullOrEmpty();
			Condition.Requires(confirmationToken).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (string.Equals(membership.ConfirmationToken, confirmationToken, StringComparison.Ordinal)) {
				membership.IsConfirmed = true;

				_membershipService.Save(membership, false);

				return true;
			}

			return false;
		}

		public override bool ConfirmAccount(string confirmationToken) {
			Condition.Requires(confirmationToken).IsNotNullOrEmpty();

			var membership = _membershipService.Get(m => m.ConfirmationToken == confirmationToken, false, true);

			if (membership != null) {
				membership.IsConfirmed = true;

				_membershipService.Save(membership, false);

				return true;
			}

			return false;
		}

		public override bool DeleteAccount(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var result = _membershipService.Delete(email, true);

			return !result.ContainsError;
		}

		public override string GeneratePasswordResetToken(string email) {
			return GeneratePasswordResetToken(email, 24*60);
		}

		public override string GeneratePasswordResetToken(string email, int tokenExpirationInMinutesFromNow) {
			Condition.Requires(email).IsNotNullOrEmpty();
			Condition.Requires(tokenExpirationInMinutesFromNow).IsNotLessThan(1);

			var membership = _membershipService.Get(email, false, true);

			if (membership == null || !membership.IsConfirmed)
				return null;

			membership.PasswordVerificationToken = GenerateToken();
			membership.PasswordVerificationTokenExpirationDateUtc = DateTime.UtcNow.AddMinutes(tokenExpirationInMinutesFromNow);

			_membershipService.Save(membership, false);

			return membership.PasswordVerificationToken;
		}

		public long GetUserIdFromPasswordVerificationToken(string token) {
			Condition.Requires(token).IsNotNullOrEmpty();

			var membership = _membershipService.Get(m => m.PasswordVerificationToken == token, false, true);

			if (membership == null)
				return 0;

			return (int) membership.User.Id;
		}

		public override int GetUserIdFromPasswordResetToken(string token) {
			throw new NotSupportedException();
		}

		public override bool IsConfirmed(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			return membership != null && membership.IsConfirmed;
		}

		public override bool ResetPasswordWithToken(string token, string newPassword) {
			Condition.Requires(token).IsNotNullOrEmpty();
			Condition.Requires(newPassword).IsNotNullOrEmpty();

			var membership = _membershipService.GetByPasswordVerificationToken(token, DateTime.UtcNow, false, true);

			if (membership == null)
				return false;

			membership.Password = Crypto.HashPassword(newPassword);
			membership.LastPasswordChangeDateUtc = DateTime.UtcNow;
			membership.PasswordVerificationToken = null;
			membership.PasswordVerificationTokenExpirationDateUtc = null;

			_membershipService.Save(membership, false);

			return true;
		}

		public override int GetPasswordFailuresSinceLastSuccess(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				return 0;

			return membership.PasswordFailuresSinceLastSuccess.GetValueOrDefault();
		}

		public override DateTime GetCreateDate(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				return default(DateTime);

			return membership.CreateDateUtc;
		}

		public override DateTime GetPasswordChangedDate(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				return default(DateTime);

			return membership.LastPasswordChangeDateUtc.GetValueOrDefault();
		}

		public override DateTime GetLastPasswordFailureDate(string email) {
			Condition.Requires(email).IsNotNullOrEmpty();

			var membership = _membershipService.Get(email, false, true);

			if (membership == null)
				return default(DateTime);

			return membership.LastPasswordFailureDateUtc.GetValueOrDefault();
		}

		private bool CheckPassword(MembershipEntity membership, string password) {
			if (!Crypto.VerifyHashedPassword(membership.Password, password)) {
				membership.LastPasswordFailureDateUtc = DateTime.UtcNow;
				membership.PasswordFailuresSinceLastSuccess++;

				if (membership.PasswordFailuresSinceLastSuccess > MaxInvalidPasswordAttempts && membership.LastPasswordFailureDateUtc.GetValueOrDefault().Add(TimeSpan.FromSeconds(PasswordAttemptWindow)) > DateTime.UtcNow)
					membership.IsLocked = true;

				_membershipService.Save(membership, false);

				return false;
			}

			if (membership.IsLocked.GetValueOrDefault() && membership.LastPasswordFailureDateUtc.GetValueOrDefault().Add(TimeSpan.FromSeconds(PasswordAttemptWindow)) <= DateTime.UtcNow)
				membership.IsLocked = false;

			membership.PasswordFailuresSinceLastSuccess = 0;

			_membershipService.Save(membership, false);

			return true;
		}

		private static string GenerateToken() {
			using (var generator = new RNGCryptoServiceProvider()) {
				var tokenBytes = new byte[TOKEN_SIZE_IN_BYTES];

				generator.GetBytes(tokenBytes);

				var token = HttpServerUtility.UrlTokenEncode(tokenBytes);

				return token;
			}
		}
	}
}