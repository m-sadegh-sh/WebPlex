namespace WebPlex.Services.Validations.Configuration {
	using NHibernate.Validator.Cfg.Loquacious;

	using WebPlex.Core.Domain.Settings;

	public sealed class CloudSettingsValidation : ValidationDef<CloudSettings> {
		public CloudSettingsValidation() {
			Define(cs => cs.ConsumerKey);

			Define(cs => cs.ConsumerSecret);

			Define(cs => cs.UserName);

			Define(cs => cs.Password);

			Define(cs => cs.BackupFolder);
		}
	}
}