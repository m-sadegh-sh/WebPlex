namespace WebPlex.MvcApplication.AutoMapping.Converters {
	using System;

	using AutoMapper;

	using WebPlex.Core.Engine;
	using WebPlex.Core.Extensions;
	using WebPlex.MvcApplication.AutoMapping.Formatters;
	using WebPlex.Services.Helpers;

	public sealed class DateTimeToStringConverter : ITypeConverter<DateTime, string> {
		private const string PRETTY_PRESENTATION_KEY = "Pretty";

		public string Convert(ResolutionContext context) {
			var value = (DateTime) context.SourceValue;

			var dateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();

			var userDateTime = dateTimeHelper.ConvertToUserTime(value);

			var toPretty = context.MemberName.Contains(PRETTY_PRESENTATION_KEY);

			if (toPretty)
				return DateTimeFormatter.FormatValue(userDateTime);

			return userDateTime.ToPersianDateString();
		}
	}
}