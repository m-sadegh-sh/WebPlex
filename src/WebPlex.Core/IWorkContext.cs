namespace WebPlex.Core {
	using System.Globalization;

	using WebPlex.Core.Domain.Entities.Security;

	public interface IWorkContext {
		UserEntity CurrentUser { get; }
		CultureInfo CurrentCulture { get; }
	}
}