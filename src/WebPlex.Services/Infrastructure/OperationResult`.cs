namespace WebPlex.Services.Infrastructure {
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	using NHibernate.Linq;
	using NHibernate.Validator.Engine;

	using WebPlex.Core.Domain.Entities;

	public sealed class OperationResult<TValue> : OperationResult {
		public TValue Value { get; set; }

		public OperationResult<TValue> With(TValue value) {
			Value = value;

			return this;
		}

		public new OperationResult<TValue> AddError(string errorMessage) {
			base.AddError(errorMessage);

			return this;
		}

		public new OperationResult<TValue> AddError(string propertyName, string errorMessage) {
			base.AddError(propertyName, errorMessage);

			return this;
		}

		public new OperationResult<TValue> AddError<TEntity>(Expression<Func<TEntity, object>> expression, string errorMessage, params object[] args) where TEntity : class, IEntity {
			base.AddError(expression, errorMessage, args);

			return this;
		}

		public static OperationResult operator +(OperationResult @this, OperationResult<TValue> that) {
			that.Errors.ForEach(@this.Errors.Add);

			return @this;
		}

		public static OperationResult<TValue> operator +(OperationResult<TValue> @this, OperationResult that) {
			that.Errors.ForEach(@this.Errors.Add);

			return @this;
		}

		public static OperationResult<TValue> operator +(OperationResult<TValue> @this, OperationResult<TValue> that) {
			that.Errors.ForEach(@this.Errors.Add);

			@this.Value = that.Value;

			return @this;
		}

		public static OperationResult<TValue> operator +(OperationResult<TValue> @this, IList<InvalidValue> that) {
			that.ForEach(iv => @this.Errors.Add(iv.PropertyName, iv.Message));

			return @this;
		}
	}
}