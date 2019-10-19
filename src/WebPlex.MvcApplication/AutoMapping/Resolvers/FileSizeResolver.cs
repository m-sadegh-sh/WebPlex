namespace WebPlex.MvcApplication.AutoMapping.Resolvers {
	using AutoMapper;

	using WebPlex.MvcApplication.AutoMapping.Formatters;

	public sealed class FileSizeResolver : IValueResolver {
		public ResolutionResult Resolve(ResolutionResult context) {
			var value = (long) context.Value;

			return context.New(FileSizeFormatter.FormatValue(value));
		}
	}
}