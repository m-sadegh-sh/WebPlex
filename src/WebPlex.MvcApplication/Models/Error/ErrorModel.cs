namespace WebPlex.MvcApplication.Models.Error {
	public sealed class ErrorModel : IModel {
		public int ErrorNum { get; set; }
		public string Heading { get; set; }
		public string Message { get; set; }
	}
}