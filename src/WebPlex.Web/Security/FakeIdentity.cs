namespace WebPlex.Web.Security {
	using System;
	using System.Security.Principal;

	public sealed class FakeIdentity : IIdentity {
		public string Name {
			get { throw new NotSupportedException(); }
		}

		public string AuthenticationType {
			get { throw new NotSupportedException(); }
		}

		public bool IsAuthenticated {
			get { return false; }
		}
	}
}