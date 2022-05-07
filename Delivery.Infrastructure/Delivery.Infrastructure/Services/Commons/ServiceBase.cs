using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Application.Services.Commons;
using Delivery.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Services.Commons
{
    public partial class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : EntityBase
    {
        #region Fields

        private readonly IReadRepository<TEntity> _entityReadRepository;
        private readonly IWriteRepository<TEntity> _entityWriteRepository;

        #endregion

        #region Ctor

        public ServiceBase(IReadRepository<TEntity> entityReadRepository, IWriteRepository<TEntity> entityWriteRepository)
        {
            _entityReadRepository = entityReadRepository;
            _entityWriteRepository = entityWriteRepository;

        }

        #endregion

        #region Methods

        #region Select

        /// <summary>
        /// Get a entity with FirstAllDefault
        /// </summary>
        /// <param name="predicate">Lambda expressions</param>
        /// <param name="includes">Lambda expressions include entities</param>
        /// <returns>Entity</returns>
        public virtual async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _entityReadRepository.GetFirstAsync(predicate, includes);
        }
        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="predicate">Lambda expressions</param>
        /// <returns>Entity IReadOnlyList</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _entityReadRepository.GetAsync(predicate);
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="predicate">Lambda expressions</param>
        /// <param name="includes">Lambda expressions include entities</param>
        /// <returns>Entity IReadOnlyList</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return await _entityReadRepository.GetAsync(predicate, includes);
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="predicate">Lambda expressions</param>
        /// <param name="orderBy">Ordered</param>
        /// <param name="includes">Lambda expressions include entity</param>
        /// <param name="disableTracking"></param>
        /// <returns>Entity IReadOnlyList</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true)
        {
            return await _entityReadRepository.GetAsync(predicate, orderBy, includeString, disableTracking);
        }

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="predicate">Lambda expressions</param>
        /// <param name="orderBy">Ordered</param>
        /// <param name="includes">Lambda expressions include entities</param>
        /// <param name="disableTracking"></param>
        /// <returns>Entity IReadOnlyList</returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       List<Expression<Func<TEntity, object>>> includes = null,
                                       bool disableTracking = true)
        {
            return await _entityReadRepository.GetAsync(predicate, orderBy, includes, disableTracking);
        }

        /// <summary>
        /// Gets a entity
        /// </summary>
        /// <param name="entityId">The entity identifier</param>
        /// <returns>Entity</returns>
        public virtual async Task<TEntity> GetByIdAsync(int entityId)
        {
            if (entityId == 0)
                return null;

            return await _entityReadRepository.GetByIdAsync(entityId);
        }


        public virtual async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<int> entityIds)
        {
            return await _entityReadRepository.GetByIdsAsync(entityIds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> CountAsync()
        {
            return await _entityReadRepository.CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public virtual IPagedList<TEntity> GetPagedEntities(Expression<Func<TEntity, bool>> predicate = null, string includeString = null, int pageIndex = 0, int pageSize = int.MaxValue, Sort sort = null)
        {
            var query = _entityReadRepository.TableNoTracking;

            if (sort != null)
                query = query.Sort(sort);
            else
                query = query.OrderBy(c => c.Id);

            return new PagedList<TEntity>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _entityReadRepository.GetAllAsync();
        }

        #endregion

        #region Insert

        /// <summary>
        /// Adds a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            //entity.DisplayOrder = CountEntitiesAsync().Result + 1;

            return _entityWriteRepository.AddAsync(entity);

        }

        /// <summary>
        /// Add entities 
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            _entityWriteRepository.AddRangeAsync(entities);
        }

        #endregion

        #region Update

        /// <summary>
        /// Updates a entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entityWriteRepository.UpdateAsync(entity);

        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _entityWriteRepository.UpdateRangeAsync(entities);
        }



        #endregion

        #region Delete

        /// <summary>
        /// Removes a entity
        /// </summary>
        /// <param name="entitiy">The entitiy</param>
        public virtual async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entityWriteRepository.RemoveAsync(entity);


        }

        /// <summary>
        /// Remove entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _entityWriteRepository.RemoveRangeAsync(entities);
        }



        #endregion

        #region Sort

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void DownEntity(TEntity entity )
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var nextEntity = _entityRepository.TableNoTracking.Where(c => c.DisplayOrder > entity.DisplayOrder).OrderBy(c => c.DisplayOrder).FirstOrDefault();
        //    if (nextEntity != null)
        //    {
        //        int entityDisplayOrder = entity.DisplayOrder;
        //        entity.DisplayOrder = nextEntity.DisplayOrder;
        //        nextEntity.DisplayOrder = entityDisplayOrder;

        //        UpdateEntityAsync(entity);
        //        UpdateEntityAsync(nextEntity);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void UpEntity(TEntity entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    var nextEntity = _entityRepository.TableNoTracking.Where(c => c.DisplayOrder < entity.DisplayOrder).OrderByDescending(c => c.DisplayOrder).FirstOrDefault();
        //    if (nextEntity != null)
        //    {
        //        int entityDisplayOrder = entity.DisplayOrder;
        //        entity.DisplayOrder = nextEntity.DisplayOrder;
        //        nextEntity.DisplayOrder = entityDisplayOrder;

        //        UpdateEntityAsync(entity);
        //        UpdateEntityAsync(nextEntity);
        //    }
        //}

        #endregion


        #endregion

    }
}
