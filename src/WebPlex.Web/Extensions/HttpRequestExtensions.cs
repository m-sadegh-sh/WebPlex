namespace WebPlex.Web.Extensions {
	using System.Collections.Generic;
	using System.Net;
	using System.Web;

	using WebPlex.Core.Extensions;

	public static class HttpRequestExtensions {
		public static string RemoteIp(this HttpRequestBase request) {
			var ip = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (ip == null)
				ip = request.ServerVariables["REMOTE_ADDR"];

			return ip;
		}

		public static string LocalIp(this HttpRequestBase request) {
			var hostName = Dns.GetHostName();

			var hostEntry = Dns.GetHostEntry(hostName);

			var addressList = hostEntry.AddressList;

			var ip = addressList[addressList.Length - 1].ToString();

			return ip;
		}

		public static IDictionary<string, string> LoggableParams(this HttpRequestBase request) {
			var @params = new Dictionary<string, string>();

			foreach (string param in request.Headers) {
				if (!string.IsNullOrEmpty(request.Params[param]))
					@params.TryToAdd(param, request.Params[param]);
			}

			foreach (string param in request.Cookies) {
				if (!string.IsNullOrEmpty(request.Params[param]))
					@params.TryToAdd(param, request.Params[param]);
			}

			foreach (string param in request.QueryString) {
				if (!string.IsNullOrEmpty(request.Params[param]))
					@params.TryToAdd(param, request.Params[param]);
			}

			foreach (string param in request.Form) {
				if (!string.IsNullOrEmpty(request.Params[param]))
					@params.TryToAdd(param, request.Params[param]);
			}

			foreach (string param in request.Files) {
				if (!string.IsNullOrEmpty(request.Params[param]))
					@params.TryToAdd(param, request.Params[param]);
			}

			return @params;
		}
	}
}