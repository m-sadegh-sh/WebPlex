namespace WebPlex.Services.Impl.Workflow {
	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Services.Infrastructure;

	public interface IEmailAccountService : IDbService<EmailAccountEntity> {
		EmailAccountEntity Get(string email, bool inVisible, bool logIfNull);

		EmailAccountEntity Get(Constant internalKey, bool inVisible, bool logIfNull);

		EmailAccountEntity GetNoReply();
		EmailAccountEntity GetInfo();
		EmailAccountEntity GetContact();
		EmailAccountEntity GetSupport();
		EmailAccountEntity GetSales();
		EmailAccountEntity GetDefault();

		OperationResult<EmailAccountEntity> Save(string email, string name, string userName, string password, string host, int port, bool sslEnabled, bool useDefaultCredentials);

		OperationResult<EmailAccountEntity> Save(string email, Constant internalKey, string name, string userName, string password, string host, int port, bool sslEnabled, bool useDefaultCredentials);

		OperationResult Delete(string email, bool onlyChangeFlag);

		OperationResult Delete(Constant internalKey, bool onlyChangeFlag);
	}
}