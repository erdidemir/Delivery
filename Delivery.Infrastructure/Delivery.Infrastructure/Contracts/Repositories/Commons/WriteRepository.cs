using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Contracts.Repositories.Commons
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase
    {
        private readonly ApplicationContext _context;
        public WriteRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #region Properties

        public virtual IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return _context.Set<T>().AsNoTracking();
            }
        }

        #endregion

        #region Insert

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                string hata = ex.ToString();
                throw;
            }
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Update
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Entry(entities).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Delete
        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

