namespace WebPlex.MvcApplication.AutoMapping.Converters {
	using System;

	using AutoMapper;

	using FarsiLibrary.Utils;

	using WebPlex.Core.Engine;
	using WebPlex.Services.Helpers;

	public sealed class DateTimeToPersianDateConverter : ITypeConverter<DateTime, PersianDate> {
		public PersianDate Convert(ResolutionContext context) {
			var sourceValue = (DateTime) context.SourceValue;

			var dateTimeHelper = EngineContext.Current.Resolve<IDateTimeHelper>();

			var userDateTime = dateTimeHelper.ConvertToUserTime(sourceValue);

			return userDateTime;
		}
	}
}