namespace WebPlex.Services {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;

	using CuttingEdge.Conditions;

	using NHibernate;
	using NHibernate.Linq;

	using WebPlex.Core.Domain.Entities;
	using WebPlex.Core.Engine;
	using WebPlex.Core.Extensions;
	using WebPlex.Data;
	using WebPlex.Resources;
	using WebPlex.Services.Infrastructure;

	public abstract class DbServiceBase<TEntity> : IDbService<TEntity> where TEntity : class, IEntity {
		private readonly IActiveSessionManager _activeSessionManager;
		private readonly ValidationProvider _validationProvider;

		protected DbServiceBase(IActiveSessionManager activeSessionManager, ValidationProvider validationProvider) {
			_activeSessionManager = activeSessionManager;
			_validationProvider = validationProvider;
		}

		protected ISession CurrentSession {
			get { return _activeSessionManager.GetActiveSession(); }
		}

		private IQueryable<TEntity> Query {
			get { return CurrentSession.Query<TEntity>(); }
		}

		public TEntity Get(long id, bool load, bool inVisible, bool logIfNull) {
			if (id < 1)
				return null;

			TEntity entity;

			if (load)
				entity = CurrentSession.Load<TEntity>(id);
			else
				entity = CurrentSession.Get<TEntity>(id);

			if (entity == null || !(inVisible || entity.IsEnabled))
				return null;

			Ensure(entity, id, logIfNull);

			return entity;
		}

		public TEntity Get(Expression<Func<TEntity, bool>> filterExpression, bool inVisible, bool logIfNull) {
			Condition.Requires(filterExpression).IsNotNull();

			var entity = Query.Where(e => inVisible || e.IsEnabled).Where(filterExpression).FirstOrDefault();

			Ensure(entity, filterExpression, logIfNull);

			return entity;
		}

		public TEntity GetCandidate<TKey>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TKey>> sortExpression, bool asc, bool inVisible, bool logIfNull) {
			Condition.Requires(filterExpression).IsNotNull();

			var entities = Query.Where(e => inVisible || e.IsEnabled).Where(filterExpression);

			if (sortExpression != null) {
				if (asc)
					entities = entities.OrderBy(sortExpression);
				else
					entities = entities.OrderByDescending(sortExpression);
			}

			var entity = entities.FirstOrDefault();

			Ensure(entity, filterExpression, logIfNull);

			return entity;
		}

		public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression, bool inVisible) {
			return GetAll<int>(filterExpression, null, true, 1, int.MaxValue, inVisible);
		}

		public IList<TEntity> GetAll<TKey>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TKey>> sortExpression, bool asc, bool inVisible) {
			return GetAll(filterExpression, sortExpression, asc, 1, int.MaxValue, inVisible);
		}

		public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression, int page, int size, bool inVisible) {
			return GetAll<int>(filterExpression, null, true, page, size, inVisible);
		}

		public IList<TEntity> GetAll<TKey>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TKey>> sortExpression, bool asc, int page, int size, bool inVisible) {
			var entities = Query.Where(e => inVisible || e.IsEnabled);

			if (filterExpression != null)
				entities = entities.Where(filterExpression);

			if (sortExpression != null) {
				if (asc)
					entities = entities.OrderBy(sortExpression);
				else
					entities = entities.OrderByDescending(sortExpression);
			}

			if (page > 0)
				entities = entities.Skip(page);

			if (size > 0)
				entities = entities.Take(size);

			return entities.ToList();
		}

		public int GetCount(Expression<Func<TEntity, bool>> filterExpression, bool inVisible) {
			var entities = Query.Where(e => inVisible || e.IsEnabled);

			if (filterExpression != null)
				entities = entities.Where(filterExpression);

			return entities.Count();
		}

		public OperationResult Save(TEntity entity, bool validateChilds) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			if (entity == null)
				return result.AddError(Messages.Common_NullEntity);

			if (HasNotExistsOnDatabase(entity))
				return result.AddError(Messages.Common_UnknownEntity);

			result += _validationProvider.Validate(entity);

			if (result.ContainsError)
				return result;

			var dbEntity = GetDatabaseVersion(entity);

			if (dbEntity != null)
				entity.Id = dbEntity.Id;

			try {
				if (entity.IsTransient()) {
					entity.Id = DateTime.UtcNow.GetTimestamp();
					CurrentSession.Save(entity);
				} else
					CurrentSession.Update(entity);
			} catch (Exception) {
				_activeSessionManager.RenewSession();

				return result.AddError(Messages.Common_SaveFailed);
			}

			return result;
		}

		public OperationResult Delete(long id, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			var entity = Get(id, true, true, true);

			if (entity == null)
				return result.AddError(Messages.Common_NullEntity);

			result += Delete(entity, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(Expression<Func<TEntity, bool>> filterExpression, bool onlyChangeFlag) {
			Condition.Requires(filterExpression).IsNotNull();

			var result = EngineContext.Current.Resolve<OperationResult>();

			var entity = Get(filterExpression, true, false);

			if (entity != null)
				result += Delete(entity, onlyChangeFlag);

			return result;
		}

		public OperationResult Delete(TEntity entity, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			if (entity == null)
				return result.AddError(Messages.Common_NullEntity);

			if (entity.IsTransient() || HasNotExistsOnDatabase(entity))
				return result.AddError(Messages.Common_UnknownEntity);

			entity.Version++;

			try {
				if (onlyChangeFlag) {
					entity.IsEnabled = false;
					CurrentSession.Update(entity);
				} else
					CurrentSession.Delete(entity);
			} catch (Exception) {
				_activeSessionManager.RenewSession();

				return result.AddError(Messages.Common_DeleteFailed);
			}

			return result;
		}

		public OperationResult DeleteAll(IEnumerable<long> ids, bool onlyChangeFlag) {
			Condition.Requires(ids).IsNotNull();

			var result = EngineContext.Current.Resolve<OperationResult>();

			foreach (var id in ids)
				result += Delete(id, onlyChangeFlag);

			return result;
		}

		public OperationResult DeleteAll(Expression<Func<TEntity, bool>> filterExpression, bool onlyChangeFlag) {
			Condition.Requires(filterExpression).IsNotNull();

			var result = EngineContext.Current.Resolve<OperationResult>();

			var entities = GetAll(filterExpression, true);

			foreach (var entity in entities)
				result += Delete(entity, onlyChangeFlag);

			return result;
		}

		public OperationResult DeleteAll(IEnumerable<TEntity> entities, bool onlyChangeFlag) {
			var result = EngineContext.Current.Resolve<OperationResult>();

			foreach (var entity in entities)
				result += Delete(entity, onlyChangeFlag);

			return result;
		}

		private bool HasNotExistsOnDatabase(TEntity entity) {
			return !entity.IsTransient() && Get(entity.Id, true, true, true) == null;
		}

		protected virtual TEntity GetDatabaseVersion(TEntity entity) {
			return null;
		}

		private void Ensure(TEntity entity, object idOrExperssion, bool logIfNull) {
			//if (entity == null && logIfNull) {
			//	var logService = EngineContext.Current.Resolve<ILogService>();

			//	logService.Warning(string.Format("Required entity (id or expression: {0}) wasn't found on database.", idOrExperssion));
			//}
		}
	}
}