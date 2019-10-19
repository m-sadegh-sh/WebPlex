namespace WebPlex.Web.Routing {
	using System;
	using System.Linq;
	using System.Web.Mvc;
	using System.Web.Routing;

	public static class RouteHelpers {
		public static readonly string UrlExtension = ".wplx";
		public static readonly Func<string, string> UrlFormatter = url => string.IsNullOrEmpty(url) ? "" : url + UrlExtension;

		public static RouteValueDictionary Convert(this object source) {
			if (source == null)
				return new RouteValueDictionary();

			if (source is RouteValueDictionary)
				return (RouteValueDictionary) source;

			return HtmlHelper.AnonymousObjectToHtmlAttributes(source);
		}

		public static RouteValueDictionary Overwrite(this object first, object second) {
			var result = Convert(first);

			foreach (var item in Convert(second)) {
				if (result.ContainsKey(item.Key))
					result[item.Key] = item.Value;
				else
					result.Add(item.Key, item.Value);
			}

			return result;
		}

		public static bool Equals(RouteValueDictionary first, RouteValueDictionary second) {
			if (ReferenceEquals(first, second))
				return true;

			if (Equals(first, null) || Equals(second, null))
				return false;

			if (first.Count != second.Count)
				return false;

			if (first.Keys.Except(second.Keys).Any())
				return false;

			if (first.Values.Except(second.Values).Any())
				return false;

			return true;
		}
	}
}