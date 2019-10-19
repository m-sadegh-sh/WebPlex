namespace WebPlex.Services.Impl.Workflow {
	using CuttingEdge.Conditions;

	using WebPlex.Core.Builders;
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Core.Engine;
	using WebPlex.Data;
	using WebPlex.Data.Knowns.Workflow;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class EmailAccountService : DbServiceBase<EmailAccountEntity>, IEmailAccountService {
		public EmailAccountService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public EmailAccountEntity Get(string email, bool inVisible, bool logIfNull) {
			if (string.IsNullOrEmpty(email))
				return null;

			var emailAccount = Get(ea => ea.Email == email, inVisible, logIfNull);

			return emailAccount;
		}

		public EmailAccountEntity Get(Constant internalKey, bool inVisible, bool logIfNull) {
			if (internalKey == null)
				return null;

			var emailAccount = Get(ea => ea.InternalKey == internalKey, inVisible, logIfNull);

			return emailAccount;
		}

		public EmailAccountEntity GetNoReply() {
			return Get(EmailAccounts.NoReply, false, true);
		}

		public EmailAccountEntity GetInfo() {
			return Get(EmailAccounts.Info, false, true);
		}

		public EmailAccountEntity GetContact() {
			return Get(EmailAccounts.Contact, false, true);
		}

		public EmailAccountEntity GetSupport() {
			return Get(EmailAccounts.Support, false, true);
		}

		public EmailAccountEntity GetSales() {
			return Get(EmailAccounts.Sales, false, true);
		}

		public EmailAccountEntity GetDefault() {
			var emailAccount = Get(ea => ea.IsDefault, false, true);

			Condition.Ensures(emailAccount).IsNotNull();

			return emailAccount;
		}

		public OperationResult<EmailAccountEntity> Save(string email, string name, string userName, string password, string host, int port, bool sslEnabled, bool useDefaultCredentials) {
			var result = EngineContext.Current.Resolve<OperationResult<EmailAccountEntity>>();

			result += Save(email, null, name, userName, password, host, port, sslEnabled, useDefaultCredentials);

			return result;
		}

		public OperationResult<EmailAccountEntity> Save(string email, Constant internalKey, string name, string userName, string password, string host, int port, bool sslEnabled, bool useDefaultCredentials) {
			var result = EngineContext.Current.Resolve<OperationResult<EmailAccountEntity>>();

			var emailAccount = internalKey != null ? Get(internalKey, true, false) : Get(email, true, false);

			if (emailAccount == null) {
				emailAccount = new EmailAccountEntity {
						IsEnabled = true,
						Email = email,
						InternalKey = internalKey,
				};
			}

			emailAccount.Name = name;
			emailAccount.UserName = userName;
			emailAccount.Password = password;
			emailAccount.Host = host;
			emailAccount.Port = port;
			emailAccount.SslEnabled = sslEnabled;
			emailAccount.UseDefaultCredentials = useDefaultCredentials;

			result += Save(emailAccount, false);

			return result.With(emailAccount);
		}

		public OperationResult Delete(string email, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var emailAccount = Get(email, true, true);

			if (emailAccount == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(emailAccount, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(Constant internalKey, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var emailAccount = Get(internalKey, true, true);

			if (emailAccount == null)
				return result.AddError(Messages.Common_UnknownEntity);

			result += Delete(emailAccount, onlyChangeFlag);

			return result;
		}

		protected override EmailAccountEntity GetDatabaseVersion(EmailAccountEntity emailAccount) {
			return Get(emailAccount.Email, true, false);
		}
	}
}