namespace WebPlex.Core.Domain.Settings {
	public sealed class ApplicationSettings : ISettings {
		public string DefaultTimeZoneId { get; set; }
		public bool AllowUsersToSetTimeZone { get; set; }
		public string DefaultLanguage { get; set; }
		public bool AllowUsersToSetLanguage { get; set; }
		public string TitleSeparator { get; set; }
		public bool IsClosed { get; set; }
		public string CloseReason { get; set; }
	}
}