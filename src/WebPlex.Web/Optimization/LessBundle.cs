namespace WebPlex.Web.Optimization {
	using System.Web.Optimization;

	public sealed class LessBundle : Bundle {
		public LessBundle(string virtualPath) : this(virtualPath, null) {}

		public LessBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath, new LessTransform(), new CssMinify()) {}
	}
}