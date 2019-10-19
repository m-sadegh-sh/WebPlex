namespace WebPlex.MvcApplication.AutoMapping.Resolvers {
	using AutoMapper;

	using MarkdownSharp;

	using WebPlex.Core.Engine;

	public sealed class MarkdownResolver : IValueResolver {
		public ResolutionResult Resolve(ResolutionResult source) {
			var value = source.Value as string;

			if (value == null)
				return source.New(string.Empty);

			var markdown = EngineContext.Current.Resolve<Markdown>();

			var html = markdown.Transform(value);

			return source.New(html);
		}
	}
}