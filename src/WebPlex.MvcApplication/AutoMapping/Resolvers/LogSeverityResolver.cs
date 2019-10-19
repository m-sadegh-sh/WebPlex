namespace WebPlex.MvcApplication.AutoMapping.Resolvers {
	using AutoMapper;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Resources;

	public sealed class LogSeverityResolver : IValueResolver {
		public ResolutionResult Resolve(ResolutionResult source) {
			var severity = (LogSeverity) source.Value;

			string value;

			switch (severity) {
				case LogSeverity.Debug:
					value = Members.LogSeverity_Debug;
					break;

				case LogSeverity.Information:
					value = Members.LogSeverity_Information;
					break;

				case LogSeverity.Warning:
					value = Members.LogSeverity_Warning;
					break;

				case LogSeverity.Error:
					value = Members.LogSeverity_Error;
					break;

				case LogSeverity.Fatal:
					value = Members.LogSeverity_Fatal;
					break;

				default:
					throw new NotSupportedEnumException(severity);
			}

			return source.New(value);
		}
	}
}