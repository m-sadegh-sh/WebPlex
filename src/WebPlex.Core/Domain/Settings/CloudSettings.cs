namespace WebPlex.Core.Domain.Settings {
	public sealed class CloudSettings : ISettings {
		public string ConsumerKey { get; set; }
		public string ConsumerSecret { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string BackupFolder { get; set; }
	}
}