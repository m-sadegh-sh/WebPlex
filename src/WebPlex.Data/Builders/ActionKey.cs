namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class ActionKey : ExpressionConstant<object> {
		public ActionKey(Expression<Func<object, object>> property) : base(property) {}
	}
}