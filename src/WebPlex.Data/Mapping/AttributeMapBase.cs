namespace WebPlex.Data.Mapping {
	using WebPlex.Core.Domain.Entities;

	public abstract class AttributeMapBase<TEntity, TKey> : EntityMapBase<TEntity> where TEntity : AttributeEntityBase<TKey> where TKey : struct {
		protected AttributeMapBase() {
			Property(a => a.Key);
			Property(a => a.Value);
		}
	}
}