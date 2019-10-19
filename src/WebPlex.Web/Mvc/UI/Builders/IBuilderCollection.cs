namespace WebPlex.Web.Mvc.UI.Builders {
	using System.Collections.Generic;

	public interface IBuilderCollection<T> : ICollection<T> where T : IBuilder {}
}