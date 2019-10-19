namespace WebPlex.MvcApplication.Models.Authenticate {
	public sealed class ExternalLoginModel : IModel {
		public string Provider { get; set; }
		public string ProviderDisplayName { get; set; }
		public string ProviderUserKey { get; set; }
	}
}