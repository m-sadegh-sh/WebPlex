namespace WebPlex.Data.Mapping {
	using NHibernate.Mapping.ByCode;

	using WebPlex.Core.Domain.Entities;

	public abstract class EntityMapBase<TEntity> : MapBase<TEntity> where TEntity : class, IEntity {
		protected EntityMapBase() {
			Id(e => e.Id, im => im.Generator(Generators.Assigned));

			Version(e => e.Version, vm => {
				                        vm.Generated(VersionGeneration.Never);
				                        vm.UnsavedValue(0);
			                        });

			Property(e => e.DisplayOrder);
			Property(e => e.IsEnabled);
		}
	}
}