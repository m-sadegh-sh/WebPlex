namespace WebPlex.Data.Builders {
	using System;
	using System.Linq.Expressions;

	public class CacheKey<T> : ExpressionConstant<T> {
		public CacheKey(params Expression<Func<T, object>>[] properties) : base(properties) {}
	}
}