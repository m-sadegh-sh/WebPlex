namespace WebPlex.Web {
	using System;
	using System.IO;
	using System.Security;
	using System.Text.RegularExpressions;
	using System.Web;
	using System.Web.Hosting;

	using CuttingEdge.Conditions;

	using WebPlex.Core;
	using WebPlex.Core.Engine;
	using WebPlex.Core.Extensions;
	using WebPlex.Web.Extensions;

	public sealed class WebHelper : IWebHelper {
		private readonly HttpRequestBase _request;
		private static AspNetHostingPermissionLevel? _trustLevel;

		public WebHelper(HttpRequestBase request) {
			_request = request;
		}

		public AspNetHostingPermissionLevel GetTrustLevel() {
			if (!_trustLevel.HasValue) {
				_trustLevel = AspNetHostingPermissionLevel.None;

				var trustLevels = new[] {AspNetHostingPermissionLevel.Unrestricted, AspNetHostingPermissionLevel.High, AspNetHostingPermissionLevel.Medium, AspNetHostingPermissionLevel.Low, AspNetHostingPermissionLevel.Minimal};

				foreach (var trustLevel in trustLevels) {
					try {
						new AspNetHostingPermission(trustLevel).Demand();
						_trustLevel = trustLevel;
						break;
					} catch (SecurityException) {}
				}
			}

			return _trustLevel.Value;
		}

		public string GetHost() {
			var useSsl = IsCurrentConnectionSecured();

			return GetHost(useSsl);
		}

		public string GetHost(bool useSsl) {
			var appHost = ServerVariables("HTTP_HOST");

			if (string.IsNullOrEmpty(appHost))
				appHost = "localhost";

			string result;

			if (useSsl)
				result = string.Concat("https://", appHost);
			else
				result = string.Concat("http://", appHost);

			if (!result.EndsWith("/"))
				result += "/";

			return result.ToLowerInvariant();
		}

		public string GetIpAddress() {
			if (_request.UserHostAddress != null)
				return _request.RemoteIp();

			return string.Empty;
		}

		public string GetLocation() {
			var useSsl = IsCurrentConnectionSecured();

			return GetLocation(useSsl);
		}

		public string GetLocation(bool useSsl) {
			var result = GetHost(useSsl);

			if (result.EndsWith("/"))
				result = result.Substring(0, result.Length - 1);

			result = result + _request.ApplicationPath;

			if (!result.EndsWith("/"))
				result += "/";

			return result.ToLowerInvariant();
		}

		public string GetUrl(bool absoluteUrl, bool includeQueryString) {
			var useSsl = IsCurrentConnectionSecured();

			return GetUrl(absoluteUrl, includeQueryString, useSsl);
		}

		public string GetUrl(bool absoluteUrl, bool includeQueryString, bool useSsl) {
			string url;

			if (includeQueryString) {
				var appHost = GetHost(useSsl);
				if (appHost.EndsWith("/"))
					appHost = appHost.Substring(0, appHost.Length - 1);
				url = appHost + _request.RawUrl;
			} else
				url = _request.Url.GetLeftPart(UriPartial.Path);

			if (!absoluteUrl)
				url = url.Replace(_request.Url.GetLeftPart(UriPartial.Authority), "");

			url = url.ToLowerInvariant();

			return url;
		}

		public string GetReferrer() {
			if (_request.UrlReferrer != null)
				return _request.UrlReferrer.ToString();

			return string.Empty;
		}

		public string MapPath(string path) {
			if (HostingEnvironment.IsHosted)
				return HostingEnvironment.MapPath(path);

			return EngineContext.Current.Resolve<HttpServerUtilityBase>().MapPath(path);
		}

		public bool IsCurrentConnectionSecured() {
			return _request.IsSecureConnection;
		}

		public string ServerVariables(string name) {
			return _request.ServerVariables.Get(name, "");
		}

		public T QueryString<T>(string name, T defaultValue = default(T)) {
			return _request.QueryString.Get(name, defaultValue);
		}

		public bool RestartAppDomain() {
			if (GetTrustLevel() > AspNetHostingPermissionLevel.Medium) {
				HttpRuntime.UnloadAppDomain();

				return TryWriteGlobalAsax();
			}

			if (TryWriteWebConfig())
				return true;

			if (TryWriteGlobalAsax())
				return true;

			return false;
		}

		public bool IsStaticResource(HttpRequestBase request) {
			Condition.Requires(request).IsNotNull();

			var extension = VirtualPathUtility.GetExtension(request.Path);

			if (extension == null)
				return false;

			switch (extension.ToLower()) {
				case ".axd":
				case ".ashx":
				case ".bmp":
				case ".css":
				case ".gif":
				case ".ico":
				case ".jpeg":
				case ".jpg":
				case ".js":
				case ".png":
				case ".rar":
				case ".zip":
					return true;
			}

			return false;
		}

		public bool IsSearchEngine(HttpRequestBase request) {
			if (request == null)
				return false;

			if (request.Browser != null && request.Browser.Crawler)
				return true;

			if (request.UserAgent != null) {
				var regex = new Regex("Twiceler|BaiDuSpider|Slurp|Ask|Teoma|Yahoo", RegexOptions.IgnoreCase);
				return regex.Match(request.UserAgent).Success;
			}

			return false;
		}

		private bool TryWriteWebConfig() {
			try {
				File.SetLastWriteTimeUtc(MapPath("~/Web.config"), DateTime.UtcNow);

				return true;
			} catch {
				return false;
			}
		}

		private bool TryWriteGlobalAsax() {
			try {
				File.SetLastWriteTimeUtc(MapPath("~/Global.asax"), DateTime.UtcNow);

				return true;
			} catch {
				return false;
			}
		}
	}
}