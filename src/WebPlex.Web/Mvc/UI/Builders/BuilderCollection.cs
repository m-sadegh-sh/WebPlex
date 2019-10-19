namespace WebPlex.Web.Mvc.UI.Builders {
	using System.Collections.ObjectModel;

	public sealed class BuilderCollection<T> : Collection<T>, IBuilderCollection<T> where T : IBuilder {}
}