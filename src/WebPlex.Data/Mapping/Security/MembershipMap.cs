namespace WebPlex.Data.Mapping.Security {
	using NHibernate.Mapping.ByCode;

	using WebPlex.Core.Domain.Entities.Security;

	public sealed class MembershipMap : EntityMapBase<MembershipEntity> {
		public MembershipMap() {
			OneToOne(m => m.User, oto => {
				                      oto.Cascade(Cascade.All | Cascade.DeleteOrphans);
				                      oto.Constrained(true);
			                      });

			Property(m => m.CreateDateUtc);
			Property(m => m.ConfirmationToken);
			Property(m => m.IsConfirmed);
			Property(m => m.Password);
			Property(m => m.LastActivityDateUtc);
			Property(m => m.LastLoginDateUtc);
			Property(m => m.LastPasswordChangeDateUtc);
			Property(m => m.LastPasswordFailureDateUtc);
			Property(m => m.PasswordFailuresSinceLastSuccess);
			Property(m => m.PasswordVerificationToken);
			Property(m => m.PasswordVerificationTokenExpirationDateUtc);
			Property(m => m.PasswordResetRequested);
			Property(m => m.LastLockoutDateUtc);
			Property(m => m.IsLocked);
			Property(m => m.LastIpAddress);
			Property(m => m.AdminComment);
		}
	}
}