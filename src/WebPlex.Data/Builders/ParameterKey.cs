namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class ParameterKey : ExpressionConstant<object> {
		public ParameterKey(Expression<Func<object, object>> expression) : base(expression) {}

		protected override string BuildPattern() {
			return null;
		}

		public override string ToString() {
			return string.Format("{{{0}}}", base.ToString());
		}
	}
}