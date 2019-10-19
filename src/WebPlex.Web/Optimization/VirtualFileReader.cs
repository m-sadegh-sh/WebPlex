namespace WebPlex.Web.Optimization {
	using System.IO;

	using WebPlex.Core;
	using WebPlex.Core.Engine;

	using dotless.Core.Input;

	public sealed class VirtualFileReader : IFileReader {
		private readonly IWebHelper _webHelper;

		public VirtualFileReader() {
			_webHelper = EngineContext.Current.Resolve<IWebHelper>();
		}

		public byte[] GetBinaryFileContents(string fileName) {
			var path = _webHelper.MapPath(fileName);

			return File.ReadAllBytes(path);
		}

		public string GetFileContents(string fileName) {
			var path = _webHelper.MapPath(fileName);

			var fileContents = File.ReadAllText(path);

			return fileContents;
		}

		public bool DoesFileExist(string fileName) {
			var path = _webHelper.MapPath(fileName);

			return File.Exists(path);
		}
	}
}