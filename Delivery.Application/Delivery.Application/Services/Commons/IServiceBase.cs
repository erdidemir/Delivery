using Delivery.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Services.Commons
{
    public partial interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        #region Select

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includes);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true);
        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                       List<Expression<Func<TEntity, object>>> includes = null,
                                       bool disableTracking = true);

        Task<TEntity> GetByIdAsync(int entityId);

        Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<int> entityIds);

        IPagedList<TEntity> GetPagedEntities(Expression<Func<TEntity, bool>> predicate = null, string includeString = null, int pageIndex = 0, int pageSize = int.MaxValue, Sort sort = null);

        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<int> CountAsync();

        #endregion

        #region Insert

        Task<TEntity> AddAsync(TEntity entity);

        void AddRangeAsync(IEnumerable<TEntity> entities);

        #endregion

        #region Update

        Task UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        #region Sort

        //void DownEntity(TEntity entity);

        //void UpEntity(TEntity entity);

        #endregion

        #endregion

        #region Delete

        Task RemoveAsync(TEntity entity);

        /// <summary>
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);

        #endregion


    }
}
