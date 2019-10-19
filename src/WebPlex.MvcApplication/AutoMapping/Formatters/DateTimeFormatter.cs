namespace WebPlex.MvcApplication.AutoMapping.Formatters {
	using System;

	using AutoMapper;

	using WebPlex.Resources;

	public sealed class DateTimeFormatter : IValueFormatter {
		public string FormatValue(ResolutionContext context) {
			var value = (DateTime) context.SourceValue;

			return FormatValue(value);
		}

		public static string FormatValue(DateTime value) {
			var subtractedValue = DateTime.UtcNow.Subtract(value);

			if (subtractedValue.TotalSeconds < 2)
				return General.PrettyTime_Now;

			if (subtractedValue.TotalSeconds < 60)
				return string.Format(General.PrettyTime_NSecAgo, subtractedValue.Seconds);

			if (subtractedValue.TotalMinutes < 2)
				return General.PrettyTime_AMinAgo;

			if (subtractedValue.TotalMinutes < 60)
				return string.Format(General.PrettyTime_NMinAgo, subtractedValue.Minutes);

			if (subtractedValue.TotalHours < 24)
				return string.Format(General.PrettyTime_NHourAgo, subtractedValue.Hours);

			if (Math.Abs(subtractedValue.TotalDays - 1) < double.Epsilon)
				return General.PrettyTime_Yesterday;

			if (subtractedValue.TotalDays < 7)
				return string.Format(General.PrettyTime_NDaysAgo, subtractedValue.Days);

			if (subtractedValue.TotalDays < 14)
				return General.PrettyTime_LastWeek;

			if (subtractedValue.TotalDays < 21)
				return General.PrettyTime_TwoWeekAgo;

			if (subtractedValue.TotalDays < 28)
				return General.PrettyTime_ThreeWeekAgo;

			if (subtractedValue.TotalDays < 60)
				return General.PrettyTime_LastMonth;

			if (subtractedValue.TotalDays < 365)
				return string.Format(General.PrettyTime_NMonthAgo, Math.Round(subtractedValue.TotalDays/30));

			if (subtractedValue.TotalDays < 730)
				return General.PrettyTime_LastYear;

			return string.Format(General.PrettyTime_NYearAgo, Math.Round(subtractedValue.TotalDays/365));
		}
	}
}