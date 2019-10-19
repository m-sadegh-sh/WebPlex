namespace WebPlex.Build {
	using System.Reflection;

	public class CurrentBuild {
		public const string Company = "WebPlex™";
		public const string Copyright = "Copyright © WebPlex™ Inc 2013";
		public const string Trademark = "WebPlex™";
		public const string Version = "0.8.*";
		public const string FileVersion = "0.8.0.0";

		public static string CurrentVersion {
			get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
		}
	}
}