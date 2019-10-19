namespace WebPlex.Core {
	using System;
	using System.Runtime.Serialization;

	[Serializable]
	public class PlexException : Exception {
		public PlexException() {}

		public PlexException(string message) : base(message) {}

		public PlexException(string messageFormat, params object[] args) : base(string.Format(messageFormat, args)) {}

		protected PlexException(SerializationInfo info, StreamingContext context) : base(info, context) {}

		public PlexException(string message, Exception innerException) : base(message, innerException) {}
	}
}