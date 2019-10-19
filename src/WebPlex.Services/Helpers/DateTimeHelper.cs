namespace WebPlex.Services.Helpers {
	using System;
	using System.Collections.ObjectModel;

	using FarsiLibrary.Utils;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Domain.Settings;
	using WebPlex.Core.Extensions;
	using WebPlex.Services.Impl.Configuration;
	using WebPlex.Services.Impl.Security;

	public sealed class DateTimeHelper : IDateTimeHelper {
		private readonly IUserAttributeService _userAttributeService;
		private readonly IApplicationSettingsService _systemSettingsService;
		private readonly IWorkContext _workContext;
		private readonly ApplicationSettings _systemSettings;

		public DateTimeHelper(IUserAttributeService userAttributeService, IApplicationSettingsService systemSettingsService, IWorkContext workContext, ApplicationSettings systemSettings) {
			_userAttributeService = userAttributeService;
			_systemSettingsService = systemSettingsService;
			_workContext = workContext;
			_systemSettings = systemSettings;
		}

		public TimeZoneInfo DefaultTimeZone {
			get {
				var timeZoneInfo = TimeZoneInfo.Local;

				if (PatternValidator.IsValidTimeZoneId(_systemSettings.DefaultTimeZoneId))
					timeZoneInfo = FindTimeZoneById(_systemSettings.DefaultTimeZoneId);

				if (_systemSettings.DefaultTimeZoneId != timeZoneInfo.Id)
					DefaultTimeZone = timeZoneInfo;

				return timeZoneInfo;
			}
			set {
				var defaultTimeZoneId = string.Empty;

				if (value != null)
					defaultTimeZoneId = value.Id;

				_systemSettings.DefaultTimeZoneId = defaultTimeZoneId;
				_systemSettingsService.SaveChanges();
			}
		}

		public TimeZoneInfo CurrentTimeZone {
			get { return GetUserTimeZone(_workContext.CurrentUser); }
			set {
				if (!_systemSettings.AllowUsersToSetTimeZone)
					return;

				var timeZoneId = string.Empty;

				if (value != null)
					timeZoneId = value.Id;

				var user = _workContext.CurrentUser;

				if (user == null)
					return;

				_userAttributeService.Save(user, UserAttribute.TimeZoneId, timeZoneId);
			}
		}

		public DateTime CurrentUserDateTime {
			get { return ConvertToUserTime(DateTime.UtcNow); }
		}

		public TimeZoneInfo FindTimeZoneById(string id) {
			return TimeZoneInfo.FindSystemTimeZoneById(id);
		}

		public ReadOnlyCollection<TimeZoneInfo> GetSystemTimeZones() {
			return TimeZoneInfo.GetSystemTimeZones();
		}

		public DateTime ConvertToUserTime(DateTime dateTime) {
			dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

			var currentUserTimeZoneInfo = CurrentTimeZone;

			return TimeZoneInfo.ConvertTime(dateTime, currentUserTimeZoneInfo);
		}

		public TimeZoneInfo GetUserTimeZone(UserEntity user) {
			TimeZoneInfo timeZoneInfo = null;

			if (_systemSettings.AllowUsersToSetTimeZone) {
				var timeZoneId = string.Empty;
				if (user != null)
					timeZoneId = _userAttributeService.GetValue(user, UserAttribute.TimeZoneId, "", false, true);

				if (PatternValidator.IsValidTimeZoneId(timeZoneId))
					timeZoneInfo = FindTimeZoneById(timeZoneId);
			}

			return timeZoneInfo ?? DefaultTimeZone;
		}

		public PersianDate TranslateToPersian(DateTime dateTime) {
			return dateTime.ToPersianDate();
		}

		public DateTime TranslateToGregorian(PersianDate persianDate) {
			return persianDate.ToGeorgianDate();
		}
	}
}