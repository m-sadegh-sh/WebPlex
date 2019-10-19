using WebActivator;

using WebPlex.MvcApplication.App_Start;

[assembly: PostApplicationStartMethod(typeof (AutoMapperConfig), "RegisterMappings")]

namespace WebPlex.MvcApplication.App_Start {
	using System;

	using AutoMapper;

	using FarsiLibrary.Utils;

	using WebPlex.MvcApplication.AutoMapping.Converters;

	public static class AutoMapperConfig {
		public static void RegisterMappings() {
			RegisterConverters();

			Mapper.AssertConfigurationIsValid();
		}

		private static void RegisterConverters() {
			Mapper.CreateMap<string, string>().ConvertUsing<NullOrEmptyStringToNotSpecifiedStringConverter>();

			Mapper.CreateMap<bool, string>().ConvertUsing<BoolToStringConverter>();

			Mapper.CreateMap<int, string>().ConvertUsing<NumericToStringResolver>();

			Mapper.CreateMap<DateTime, string>().ConvertUsing<DateTimeToStringConverter>();

			Mapper.CreateMap<DateTime, PersianDate>().ConvertUsing<DateTimeToPersianDateConverter>();
		}
	}
}