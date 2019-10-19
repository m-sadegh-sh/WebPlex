namespace WebPlex.Web.Modules {
	using System;
	using System.IO;
	using System.Text;
	using System.Text.RegularExpressions;

	using Utilities.Compression.ExtensionMethods;
	using Utilities.Compression.ExtensionMethods.Enums;

	public sealed class UglyStream : Stream {
		private readonly Stream _stream;
		private readonly CompressionType _compressionType;
		private string _finalString;

		public override bool CanRead {
			get { return false; }
		}

		public override bool CanSeek {
			get { return false; }
		}

		public override bool CanWrite {
			get { return true; }
		}

		public override long Length {
			get { throw new NotImplementedException(); }
		}

		public override long Position {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		public UglyStream(Stream stream, CompressionType compressionType) {
			_stream = stream;
			_compressionType = compressionType;
		}

		public override void Flush() {
			if (string.IsNullOrEmpty(_finalString))
				return;

			_finalString = Regex.Replace(_finalString, "/// <.+>", "");
			_finalString = Regex.Replace(_finalString, ">[\\s\\S]*?<", Evaluate);

			var bytes = Encoding.UTF8.GetBytes(_finalString);
			var buffer = bytes.Compress(_compressionType);
			_stream.Write(buffer, 0, buffer.Length);

			_finalString = "";
		}

		public override int Read(byte[] buffer, int offset, int count) {
			throw new NotImplementedException();
		}

		public override long Seek(long offset, SeekOrigin origin) {
			throw new NotImplementedException();
		}

		public override void SetLength(long value) {
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count) {
			var bytes = new byte[count];

			Buffer.BlockCopy(buffer, offset, bytes, 0, count);

			_finalString += Encoding.UTF8.GetString(bytes);
		}

		private static string Evaluate(Match matcher) {
			return Regex.Replace(matcher.ToString(), "\\r\\n\\s*", "");
		}
	}
}