namespace WebPlex.MvcApplication.AutoMapping.Converters {
	using AutoMapper;

	using WebPlex.Resources;

	public sealed class NullOrEmptyStringToNotSpecifiedStringConverter : ITypeConverter<string, string> {
		public string Convert(ResolutionContext context) {
			var sourceValue = context.SourceValue as string;

			if (sourceValue != null)
				return sourceValue;

			return General.String_NotSpecified;
		}
	}
}