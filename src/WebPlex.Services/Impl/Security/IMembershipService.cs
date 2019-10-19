namespace WebPlex.Services.Impl.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface IMembershipService : IDbService<MembershipEntity> {
		MembershipEntity Get(UserEntity user, bool inVisible, bool logIfNull);

		MembershipEntity Get(string email, bool inVisible, bool logIfNull);

		MembershipEntity GetByPasswordVerificationToken(string token, DateTime? expirationDateUtc, bool inVisible, bool logIfNull);

		OperationResult<MembershipEntity> Save(UserEntity user, string confirmationToken, bool isConfirmed, string password, DateTime createDateUtc, string adminComment);

		OperationResult Detele(UserEntity user, bool onlyChangeFlag);

		OperationResult Delete(string email, bool onlyChangeFlag);
	}
}