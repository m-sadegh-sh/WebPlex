namespace WebPlex.Core.Domain.Settings {
	public sealed class ContactFormSettings : ISettings {
		public string RecipientName { get; set; }
		public string Subject { get; set; }
	}
}