namespace WebPlex.Services.Impl.Security {
	using System;

	using WebPlex.Core.Domain.Entities.Security;
	using WebPlex.Services.Infrastructure;

	public interface ILogService : IDbService<LogEntity> {
		bool IsEnabled(LogSeverity severity);

		OperationResult<LogEntity> Debug(string message, Exception exception = null, UserEntity user = null);

		OperationResult<LogEntity> Information(string message, Exception exception = null, UserEntity user = null);

		OperationResult<LogEntity> Warning(string message, Exception exception = null, UserEntity user = null);

		OperationResult<LogEntity> Error(string message, Exception exception = null, UserEntity user = null);

		OperationResult<LogEntity> Fatal(string message, Exception exception = null, UserEntity user = null);

		OperationResult<LogEntity> Save(LogSeverity severity, string fullMessage, string stackTrace, UserEntity invoker);
	}
}