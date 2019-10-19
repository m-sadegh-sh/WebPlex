namespace WebPlex.MvcApplication.AutoMapping.Formatters {
	using AutoMapper;

	using WebPlex.Resources;

	public sealed class FileSizeFormatter : IValueFormatter {
		private const long KILOBYTE = 1024;
		private const long MEGABYTE = 1024*KILOBYTE;
		private const long GIGABYTE = 1024*MEGABYTE;
		private const long TERABYTE = 1024*GIGABYTE;

		public string FormatValue(ResolutionContext context) {
			var value = (long) context.SourceValue;

			return FormatValue(value);
		}

		public static string FormatValue(long value) {
			if (value > TERABYTE)
				return (value/TERABYTE).ToString(General.PrettySize_Terabyte);

			if (value > GIGABYTE)
				return (value/GIGABYTE).ToString(General.PrettySize_Gigabyte);

			if (value > MEGABYTE)
				return (value/MEGABYTE).ToString(General.PrettySize_Megabyte);

			if (value > KILOBYTE)
				return (value/KILOBYTE).ToString(General.PrettySize_Kilobyte);

			return value.ToString(General.PrettySize_Bytes);
		}
	}
}