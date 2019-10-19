namespace WebPlex.Web.Optimization {
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using System.Web.Optimization;

	using dotless.Core;
	using dotless.Core.configuration;

	public sealed class LessTransform : IBundleTransform {
		private IDictionary<string, string> _tokens;

		public IDictionary<string, string> Tokens {
			get { return _tokens ?? (_tokens = new Dictionary<string, string>()); }
			set { _tokens = value; }
		}

		public void Process(BundleContext context, BundleResponse response) {
			var content = response.Content;

			if (string.IsNullOrEmpty(content))
				return;

			foreach (var token in Tokens)
				content = Regex.Replace(content, token.Key, token.Value);

			response.Content = Transform(content);
			response.ContentType = "text/css";
		}

		public static string Transform(string content) {
			var config = new DotlessConfiguration {
					ImportAllFilesAsLess = true,
					CacheEnabled = false,
					Debug = true,
					LessSource = typeof (VirtualFileReader),
					Logger = typeof (LessLogger)
			};

			return Less.Parse(content, config);
		}
	}
}