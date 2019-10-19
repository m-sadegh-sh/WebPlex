namespace WebPlex.Services.Infrastructure {
	using System;
	using System.Linq;

	using WebPlex.Resources;

	public static class ValidationHelpers {
		public static string Required(string label) {
			return string.Format(Messages.Validation_Required, label);
		}

		public static string InvalidMinLength<T>(string label, T minLength) {
			return string.Format(Messages.Validation_InvalidMinLength, label, minLength);
		}

		public static string InvalidMaxLength<T>(string label, T maxLength) {
			return string.Format(Messages.Validation_InvalidMaxLength, label, maxLength);
		}

		public static string InvalidRangeLength<T>(string label, T minLength, T maxLength) {
			return string.Format(Messages.Validation_InvalidRangeLength, label, minLength, maxLength);
		}

		public static string InvalidMinValue<T>(string label, T minValue) {
			return string.Format(Messages.Validation_InvalidMinValue, label, minValue);
		}

		public static string InvalidMaxValue<T>(string label, T maxValue) {
			return string.Format(Messages.Validation_InvalidMaxValue, label, maxValue);
		}

		public static string InvalidRangeValue<T>(string label, T minValue, T maxValue) {
			return string.Format(Messages.Validation_InvalidRangeValue, label, minValue, maxValue);
		}

		public static string PositiveNumericRequired(string label) {
			return string.Format(Messages.Validation_PositiveNumericRequired, label);
		}

		public static string InvalidEmail(string label) {
			return string.Format(Messages.Validation_InvalidEmail, label);
		}

		public static string InvalidSlug(string label) {
			return string.Format(Messages.Validation_InvalidSlug, label);
		}

		public static string InvalidDateTime(string label) {
			return string.Format(Messages.Validation_InvalidDateTime, label);
		}

		public static string InvalidIpAddress(string label) {
			return string.Format(Messages.Validation_InvalidIpAddress, label);
		}

		public static string InvalidCultureCode(string label) {
			return string.Format(Messages.Validation_InvalidCultureCode, label);
		}

		public static string InvalidUrl(string label) {
			return string.Format(Messages.Validation_InvalidUrl, label);
		}

		public static string InvalidTimeZoneId(string label) {
			return string.Format(Messages.Validation_InvalidTimeZoneId, label);
		}

		public static string DuplicateValue<T>(string label, T value) {
			return string.Format(Messages.Validation_DuplicateValue, value, label);
		}

		public static string DuplicateValues(params Tuple<string, object>[] tuples) {
			var labels = string.Join(",", tuples.Select(t => t.Item1));
			var values = string.Join(",", tuples.Select(t => t.Item2));

			return string.Format(Messages.Validation_DuplicateValues, values, labels);
		}

		public static string NotMatched(string label, string label2) {
			return string.Format(Messages.Validation_NotMatched, label, label2);
		}
	}
}