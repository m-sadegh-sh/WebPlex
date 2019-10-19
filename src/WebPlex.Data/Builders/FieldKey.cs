namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class FieldKey<T> : ExpressionConstant<T> {
		public FieldKey(Expression<Func<T, object>> property) : base(property) {}

		public override bool CanHandleResources {
			get { return true; }
		}
	}
}