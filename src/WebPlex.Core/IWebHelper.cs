namespace WebPlex.Core {
	using System.Web;

	public interface IWebHelper {
		AspNetHostingPermissionLevel GetTrustLevel();
		string GetHost();
		string GetHost(bool useSsl);
		string GetIpAddress();
		string GetLocation();
		string GetLocation(bool useSsl);

		string GetUrl(bool absoluteUrl, bool includeQueryString);

		string GetUrl(bool absoluteUrl, bool includeQueryString, bool useSsl);

		string GetReferrer();
		string MapPath(string path);
		bool IsCurrentConnectionSecured();
		string ServerVariables(string name);

		TValue QueryString<TValue>(string name, TValue defaultValue = default(TValue));

		bool RestartAppDomain();
		bool IsStaticResource(HttpRequestBase request);
		bool IsSearchEngine(HttpRequestBase request);
	}
}