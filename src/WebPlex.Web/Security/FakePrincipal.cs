namespace WebPlex.Web.Security {
	using System;
	using System.Security.Principal;

	public sealed class FakePrincipal : IPrincipal {
		public FakePrincipal() {
			Identity = new FakeIdentity();
		}

		public bool IsInRole(string role) {
			throw new NotSupportedException();
		}

		public IIdentity Identity { get; private set; }
	}
}