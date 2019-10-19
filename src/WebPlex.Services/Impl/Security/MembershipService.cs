namespace WebPlex.Services.Impl.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Services.Infrastructure;

	public sealed class MembershipService : DbServiceBase<MembershipEntity>, IMembershipService {
		public MembershipService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public MembershipEntity Get(UserEntity user, bool inVisible, bool logIfNull) {
			if (user == null)
				return null;

			var membership = Get(m => m.User == user, inVisible, logIfNull);

			return membership;
		}

		public MembershipEntity Get(string email, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(email))
				return null;

			var membership = Get(m => m.User.Email == email, inVisible, logIfNull);

			return membership;
		}

		public MembershipEntity GetByPasswordVerificationToken(string token, DateTime? expirationDateUtc, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(token))
				return null;

			var user = Get(m => m.PasswordVerificationToken == token && (expirationDateUtc == null || m.PasswordVerificationTokenExpirationDateUtc >= expirationDateUtc), inVisible, logIfNull);

			return user;
		}

		public OperationResult<MembershipEntity> Save(UserEntity user, string confirmationToken, bool isConfirmed, string password, DateTime createDateUtc, string adminComment) {
			var result = EngineContext.Current.Resolve<OperationResult<MembershipEntity>>();

			var membership = Get(user, true, false);

			if (membership == null) {
				membership = new MembershipEntity {
						IsEnabled = true,
						User = user
				};
			}

			membership.ConfirmationToken = confirmationToken;
			membership.IsConfirmed = isConfirmed;
			membership.Password = password;
			membership.CreateDateUtc = createDateUtc;
			membership.LastActivityDateUtc = createDateUtc;
			membership.AdminComment = adminComment;

			result += Save(membership, false);

			return result.With(membership);
		}

		public OperationResult Detele(UserEntity user, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var membership = Get(user, true, true);

			result += Delete(membership, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(string email, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var membership = Get(email, true, true);

			result += Delete(membership, onlyChangeFlag);

			return result;
		}

		protected override MembershipEntity GetDatabaseVersion(MembershipEntity membership) {
			return Get(membership.User, true, false);
		}
	}
}