namespace WebPlex.Services.Impl.Security {
	using System;
	using System.Threading;

	using WebPlex.Core;
	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Core.Engine;
	using WebPlex.Core.Extensions;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public sealed class LogService : DbServiceBase<LogEntity>, ILogService {
		public LogService(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) : base(activeSessionManager, validationProvider) {}

		public bool IsEnabled(LogSeverity severity) {
			switch (severity) {
				case LogSeverity.Debug:
					return false;

				case LogSeverity.Information:
				case LogSeverity.Warning:
				case LogSeverity.Error:
				case LogSeverity.Fatal:
					return true;

				default:
					throw new NotSupportedEnumException(severity);
			}
		}

		public OperationResult<LogEntity> Debug(string message, Exception exception = null, UserEntity user = null) {
			return BuildLog(LogSeverity.Debug, message, exception, user);
		}

		public OperationResult<LogEntity> Information(string message, Exception exception = null, UserEntity user = null) {
			return BuildLog(LogSeverity.Information, message, exception, user);
		}

		public OperationResult<LogEntity> Warning(string message, Exception exception = null, UserEntity user = null) {
			return BuildLog(LogSeverity.Warning, message, exception, user);
		}

		public OperationResult<LogEntity> Error(string message, Exception exception = null, UserEntity user = null) {
			return BuildLog(LogSeverity.Error, message, exception, user);
		}

		public OperationResult<LogEntity> Fatal(string message, Exception exception = null, UserEntity user = null) {
			return BuildLog(LogSeverity.Fatal, message, exception, user);
		}

		private OperationResult<LogEntity> BuildLog(LogSeverity severity, string message, Exception exception, UserEntity user) {
			var result = EngineContext.Current.Resolve<OperationResult<LogEntity>>();

			if (exception is ThreadAbortException)
				return result.AddError(Messages.Logging_ThreadAbortExceptionIsNotAllowedToBeLogged);

			if (!IsEnabled(severity))
				return result.AddError(Messages.Logging_LogsWithThisTypeOfSeverityIsDisabled);

			result += Save(severity, message, exception.ToFriendlyString(), user);

			return result;
		}

		public OperationResult<LogEntity> Save(LogSeverity severity, string fullMessage, string stackTrace, UserEntity invoker) {
			var result = EngineContext.Current.Resolve<OperationResult<LogEntity>>();

			var webHelper = EngineContext.Current.Resolve<IWebHelper>();

			var log = new LogEntity {
					IsEnabled = true,
					Severity = severity,
					LogDateUtc = DateTime.UtcNow,
					FullMessage = fullMessage,
					StackTrace = stackTrace,
					RequestUrl = webHelper.GetUrl(true, true),
					ReferrerUrl = webHelper.GetReferrer(),
					Invoker = invoker,
					InvokerIp = webHelper.GetIpAddress()
			};

			result += Save(log, false);

			return result.With(log);
		}
	}
}