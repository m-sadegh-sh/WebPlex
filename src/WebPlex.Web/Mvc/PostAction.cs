namespace WebPlex.Web.Mvc {
	public enum PostAction : sbyte {
		Unknown = -1,
		PublishAll = 0,
		UnpublishAll = 1,
		TemporarilyDeleteAll = 2,
		PermanentlyDeleteAll = 4,
		UnDeleteAll = 8,
	}
}