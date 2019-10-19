namespace WebPlex.MvcApplication.AutoMapping.Converters {
	using AutoMapper;

	using WebPlex.Resources;

	public sealed class BoolToStringConverter : ITypeConverter<bool, string> {
		public string Convert(ResolutionContext context) {
			var sourceValue = (bool) context.SourceValue;

			return sourceValue ? General.Boolean_True : General.Boolean_False;
		}
	}
}