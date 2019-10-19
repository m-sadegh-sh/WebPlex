namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class EnumKey<T> : ExpressionConstant<T> {
		public EnumKey(Expression<Func<T, object>> property) : base(property) {}

		public override bool CanHandleResources {
			get { return true; }
		}
	}
}