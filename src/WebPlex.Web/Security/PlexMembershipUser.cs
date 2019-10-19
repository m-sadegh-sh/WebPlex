namespace WebPlex.Web.Security {
	using System;
	using System.Web.Security;

	using WebPlex.Core.Domain.Entities.Security;

	public sealed class PlexMembershipUser : MembershipUser {
		private readonly bool _isOnline;

		public override string ProviderName {
			get { return "plexMembershipProvider"; }
		}

		public long UserId { get; private set; }

		public override object ProviderUserKey {
			get { return (int) UserId; }
		}

		public override string UserName {
			get { return Email; }
		}

		public override string PasswordQuestion {
			get { throw new NotSupportedException(); }
		}

		public bool IsConfirmed { get; private set; }

		public override bool IsApproved {
			get { return IsConfirmed; }
			set { throw new NotSupportedException(); }
		}

		public DateTime? CreateDateUtc { get; private set; }

		public override DateTime CreationDate {
			get { return CreateDateUtc.GetValueOrDefault(); }
		}

		public DateTime? LastActivityDateUtc { get; private set; }

		public override DateTime LastActivityDate {
			get { return LastActivityDateUtc.GetValueOrDefault(); }
			set { throw new NotSupportedException(); }
		}

		public DateTime? LastLoginDateUtc { get; private set; }

		public override DateTime LastLoginDate {
			get { return LastLoginDateUtc.GetValueOrDefault(); }
			set { throw new NotSupportedException(); }
		}

		public DateTime? LastPasswordChangedDateUtc { get; private set; }

		public override DateTime LastPasswordChangedDate {
			get { return LastPasswordChangedDateUtc.GetValueOrDefault(); }
		}

		public DateTime? LastLockoutDateUtc { get; private set; }

		public override DateTime LastLockoutDate {
			get { return LastLockoutDateUtc.GetValueOrDefault(); }
		}

		public bool IsLocked { get; private set; }

		public override bool IsLockedOut {
			get { return IsLocked; }
		}

		public string LastIpAddress { get; private set; }

		public string AdminComment { get; private set; }

		public override string Comment {
			get { return AdminComment; }
			set { throw new NotSupportedException(); }
		}

		public override bool IsOnline {
			get { return _isOnline; }
		}

		public PlexMembershipUser(long userId,
				string email,
				bool isConfirmed,
				DateTime createDateUtc,
				DateTime? lastActivityDateUtc,
				DateTime? lastLoginDateUtc,
				DateTime? lastPasswordChangeDateUtc,
				DateTime? lastLockoutDateUtc,
				bool? isLocked,
				string lastIpAddress,
				string adminComment) {
			UserId = userId;
			Email = email;
			IsConfirmed = isConfirmed;
			CreateDateUtc = createDateUtc;
			LastActivityDateUtc = lastActivityDateUtc;
			LastLoginDateUtc = lastLoginDateUtc;
			LastPasswordChangedDateUtc = lastPasswordChangeDateUtc;
			LastLockoutDateUtc = lastLockoutDateUtc;
			IsLocked = isLocked.GetValueOrDefault();
			LastIpAddress = lastIpAddress;
			AdminComment = adminComment;

			if (lastActivityDateUtc != null)
				_isOnline = lastActivityDateUtc > DateTime.UtcNow.Subtract(new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0));
		}

		public override string GetPassword() {
			throw new NotSupportedException();
		}

		public override string GetPassword(string passwordAnswer) {
			throw new NotSupportedException();
		}

		public override bool ChangePassword(string oldPassword, string newPassword) {
			return PlexSecurity.Provider.ChangePassword(Email, oldPassword, newPassword);
		}

		public override bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer) {
			throw new NotSupportedException();
		}

		public override string ResetPassword() {
			return PlexSecurity.Provider.ResetPassword(Email);
		}

		public override string ResetPassword(string passwordAnswer) {
			throw new NotSupportedException();
		}

		public override bool UnlockUser() {
			return PlexSecurity.Provider.UnlockUser(Email);
		}

		public override string ToString() {
			return Email;
		}

		public static implicit operator PlexMembershipUser(UserEntity value) {
			if (value == null)
				return null;

			var membership = value.Membership;

			if (membership == null)
				return null;

			return new PlexMembershipUser(value.Id, value.Email, membership.IsConfirmed, membership.CreateDateUtc, membership.LastActivityDateUtc, membership.LastLoginDateUtc, membership.LastPasswordChangeDateUtc, membership.LastLockoutDateUtc,
					membership.IsLocked, membership.LastIpAddress, membership.AdminComment);
		}
	}
}