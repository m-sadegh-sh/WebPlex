namespace WebPlex.Services {
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	using WebPlex.Core.Domain.Entities;
	using WebPlex.Services.Infrastructure;

	public interface IDbService<TEntity> where TEntity : class, IEntity {
		TEntity Get(long id, bool load, bool inVisible, bool logIfNull);

		TEntity Get(Expression<Func<TEntity, bool>> filterExpression, bool inVisible, bool logIfNull);

		TEntity GetCandidate<TKey>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TKey>> sortExpression, bool asc, bool inVisible, bool logIfNull);

		IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression, bool inVisible);

		IList<TEntity> GetAll<TKey>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TKey>> sortExpression, bool asc, bool inVisible);

		IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression, int page, int size, bool inVisible);

		IList<TEntity> GetAll<TKey>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TKey>> sortExpression, bool asc, int page, int size, bool inVisible);

		int GetCount(Expression<Func<TEntity, bool>> filterExpression, bool inVisible);

		OperationResult Save(TEntity entity, bool validateChilds);

		OperationResult Delete(long id, bool onlyChangeFlag);

		OperationResult Delete(Expression<Func<TEntity, bool>> filterExpression, bool onlyChangeFlag);

		OperationResult Delete(TEntity entity, bool onlyChangeFlag);

		OperationResult DeleteAll(IEnumerable<long> ids, bool onlyChangeFlag);

		OperationResult DeleteAll(Expression<Func<TEntity, bool>> filterExpression, bool onlyChangeFlag);

		OperationResult DeleteAll(IEnumerable<TEntity> entities, bool onlyChangeFlag);
	}
}