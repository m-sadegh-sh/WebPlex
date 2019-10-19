namespace WebPlex.Core.Domain.Entities.Security {
	using System;

	public class MembershipEntity : EntityBase {
		public virtual UserEntity User { get; set; }
		public virtual DateTime CreateDateUtc { get; set; }
		public virtual string ConfirmationToken { get; set; }
		public virtual bool IsConfirmed { get; set; }
		public virtual string Password { get; set; }
		public virtual DateTime? LastActivityDateUtc { get; set; }
		public virtual DateTime? LastLoginDateUtc { get; set; }
		public virtual DateTime? LastPasswordChangeDateUtc { get; set; }
		public virtual DateTime? LastPasswordFailureDateUtc { get; set; }
		public virtual int? PasswordFailuresSinceLastSuccess { get; set; }
		public virtual string PasswordVerificationToken { get; set; }
		public virtual DateTime? PasswordVerificationTokenExpirationDateUtc { get; set; }
		public virtual bool PasswordResetRequested { get; set; }
		public virtual DateTime? LastLockoutDateUtc { get; set; }
		public virtual bool? IsLocked { get; set; }
		public virtual string LastIpAddress { get; set; }
		public virtual string AdminComment { get; set; }
	}
}