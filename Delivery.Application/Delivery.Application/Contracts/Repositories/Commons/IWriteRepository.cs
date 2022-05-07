using Delivery.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Contracts.Repositories.Commons
{
    public interface IWriteRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        #region Insert

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        #endregion

        #region Update

        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        #endregion

        #region Delete

        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

        #endregion
    }
}
