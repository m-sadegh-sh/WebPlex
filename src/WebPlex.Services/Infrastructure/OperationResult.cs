namespace WebPlex.Services.Infrastructure {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Web.Mvc;

	using NHibernate.Linq;
	using NHibernate.Validator.Engine;

	using Utilities.Reflection.ExtensionMethods;

	using WebPlex.Core.Domain.Entities;

	public class OperationResult {
		public OperationResult() {
			Errors = new Dictionary<string, string>();
		}

		public IDictionary<string, string> Errors { get; set; }

		public bool ContainsError {
			get { return Errors.Any(); }
		}

		public OperationResult AddError(string errorMessage) {
			return AddError(string.Empty, errorMessage);
		}

		public OperationResult AddError(string propertyName, string errorMessage) {
			Errors.Add(propertyName, errorMessage);

			return this;
		}

		public OperationResult AddError<TEntity>(Expression<Func<TEntity, object>> expression, string errorMessage, params object[] args) where TEntity : class, IEntity {
			var propertyName = expression.GetPropertyName();

			if (args.Any())
				errorMessage = string.Format(errorMessage, args);

			return AddError(propertyName, errorMessage);
		}

		public static OperationResult operator +(OperationResult @this, OperationResult that) {
			that.Errors.ForEach(@this.Errors.Add);

			return @this;
		}

		public static OperationResult operator +(OperationResult @this, IList<InvalidValue> that) {
			that.ForEach(iv => @this.Errors.Add(iv.PropertyName, iv.Message));

			return @this;
		}

		public void CopyTo(ModelStateDictionary modelState) {
			foreach (var error in Errors)
				modelState.AddModelError(error.Key, error.Value);
		}
	}
}