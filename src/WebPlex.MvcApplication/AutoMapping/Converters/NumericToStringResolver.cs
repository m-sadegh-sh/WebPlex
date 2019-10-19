namespace WebPlex.MvcApplication.AutoMapping.Converters {
	using System.Globalization;

	using AutoMapper;

	using WebPlex.Resources;

	public sealed class NumericToStringResolver : ITypeConverter<int, string> {
		public string Convert(ResolutionContext context) {
			var sourceValue = (int) context.SourceValue;

			if (sourceValue == 0)
				return General.Numeric_NotSpecified;

			return sourceValue.ToString(CultureInfo.InvariantCulture);
		}
	}
}