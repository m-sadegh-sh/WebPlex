namespace WebPlex.Services.Helpers {
	using System;
	using System.Collections.ObjectModel;

	using FarsiLibrary.Utils;

	using WebPlex.Core.Domain.Entities.Security;

	public interface IDateTimeHelper {
		TimeZoneInfo DefaultTimeZone { get; set; }

		TimeZoneInfo CurrentTimeZone { get; set; }

		DateTime CurrentUserDateTime { get; }

		TimeZoneInfo FindTimeZoneById(string id);

		ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones();

		DateTime ConvertToUserTime(DateTime dateTime);

		TimeZoneInfo GetUserTimeZone(UserEntity user);

		PersianDate TranslateToPersian(DateTime dateTime);

		DateTime TranslateToGregorian(PersianDate persianDate);
	}
}