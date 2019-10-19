namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class MessageKey : ExpressionConstant<object> {
		public MessageKey(Expression<Func<object, object>> property) : base(property) {}

		public override bool CanHandleResources {
			get { return true; }
		}
	}
}