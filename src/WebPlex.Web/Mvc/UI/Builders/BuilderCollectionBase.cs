namespace WebPlex.Web.Mvc.UI.Builders {
	using System;

	using WebPlex.Web.Mvc.UI.Components;

	public abstract class BuilderCollectionBase<T, TBuilder> : BuilderBase<T, TBuilder> where T : IComponent {
		protected TNestedBuilder Child<TNestedBuilder>(Action<TNestedBuilder> action) where TNestedBuilder : IBuilder {
			var builder = Activator.CreateInstance<TNestedBuilder>();

			action(builder);

			return builder;
		}

		protected IBuilderCollection<TNestedBuilder> Children<TNestedBuilder>(Action<ChildrenExpression<TNestedBuilder>> action) where TNestedBuilder : IBuilder {
			var builder = Activator.CreateInstance<ChildrenExpression<TNestedBuilder>>();

			action(builder);

			return builder.Builders;
		}
	}
}