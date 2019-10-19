namespace WebPlex.Web.Mvc.Feed {
	using System.Text.RegularExpressions;

	internal static class RtlHelper {
		private static readonly Regex _matchArabicHebrew = new Regex(@"[\u0600-\u06FF,\u0590-\u05FF]", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		public static string CorrectRtl(this string title) {
			if (string.IsNullOrWhiteSpace(title))
				return string.Empty;

			const char rleChar = (char) 0x202B;
			if (_matchArabicHebrew.IsMatch(title))
				return rleChar + title;

			return title;
		}

		public static string CorrectRtlBody(this string body) {
			if (string.IsNullOrWhiteSpace(body))
				return string.Empty;

			if (_matchArabicHebrew.IsMatch(body))
				return "<div style='text-align: right; font-family:tahoma; font-size:9pt;' dir='rtl'>" + body + "</div>";
			return "<div style='text-align: left; font-family:tahoma; font-size:9pt;' dir='ltr'>" + body + "</div>";
		}
	}
}