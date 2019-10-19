namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class InternalKey : ExpressionConstant<object> {
		private readonly Expression<Func<object, object>> _expression;

		public InternalKey(Expression<Func<object, object>> expression) : base(null) {
			_expression = expression;
		}

		protected override string BuildKey() {
			return _expression.Body.ToString();
		}
	}
}