namespace WebPlex.Data.Mapping.Security {
	using WebPlex.Core.Domain.Entities.Security;

	public sealed class UserAttributeMap : AttributeMapBase<UserAttributeEntity, UserAttribute> {
		public UserAttributeMap() {
			ManyToOne(ua => ua.User);
		}
	}
}