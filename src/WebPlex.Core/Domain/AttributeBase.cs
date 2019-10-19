namespace FaraMedia.Core.Domain {
	public abstract class AttributeBase : EntityBase {
		public virtual string SystemName { get; set; }
		public virtual string DisplayName { get; set; }
		public virtual string Description { get; set; }
	}
}