namespace WebPlex.Web.Security {
	using System.Web.Security;

	using WebMatrix.WebData;

	public static class PlexSecurity {
		public static PlexMembershipProvider Provider {
			get { return (PlexMembershipProvider) Membership.Provider; }
		}

		public static PlexMembershipUser CurrentUser {
			get { return Provider.GetUser(WebSecurity.CurrentUserId, false); }
		}
	}
}