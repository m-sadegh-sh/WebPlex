namespace WebPlex.Data.Mapping.Workflow {
	using WebPlex.Core.Domain.Entities.Workflow;
	using WebPlex.Data.NHibernating.CustomTypes;

	public sealed class EmailAccountMap : EntityMapBase<EmailAccountEntity> {
		public EmailAccountMap() {
			Property(ea => ea.Email);
			Property(ea => ea.InternalKey, pm => pm.Type<ConstantType>());
			Property(ea => ea.Name);
			Property(ea => ea.UserName);
			Property(ea => ea.Password);
			Property(ea => ea.Host);
			Property(ea => ea.Port);
			Property(ea => ea.SslEnabled);
			Property(ea => ea.UseDefaultCredentials);
			Property(ea => ea.IsDefault);
		}
	}
}