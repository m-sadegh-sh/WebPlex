namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	public sealed class ChildrenExpression<T> where T : IBuilder {
		private IBuilderCollection<T> _builders;

		public IBuilderCollection<T> Builders {
			get { return _builders ?? (_builders = new BuilderCollection<T>()); }
			set { _builders = value; }
		}

		public T Add {
			get {
				var builder = Activator.CreateInstance<T>();

				Builders.Add(builder);

				return builder;
			}
		}
	}
}