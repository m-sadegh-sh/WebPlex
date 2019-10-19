namespace WebPlex.Web.Optimization {
	using System;

	using dotless.Core.Loggers;

	public sealed class LessLogger : Logger {
		public LessLogger() : base(LogLevel.Info) {}

		protected override void Log(string message) {
			throw new Exception(message);
		}
	}
}