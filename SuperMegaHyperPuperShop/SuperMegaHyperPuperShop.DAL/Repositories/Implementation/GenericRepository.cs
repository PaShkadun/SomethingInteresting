using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity, CancellationToken token)
        {
            var result = await _context.AddAsync(entity, token);

            await _context.SaveChangesAsync(token);

            return (T) result.Entity;
        }

        public virtual async Task<IEnumerable<T>> Get(CancellationToken token)
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync(token);

            return result;
        }

        public virtual async Task<T> GetById(int id, CancellationToken token)
        {
            var set = _context.Set<T>();
            var result = await set.FindAsync(id, token);

            return result;
        }

        public virtual async Task<T> Update(T entity, CancellationToken token)
        {
            var result = _context.Update<T>(entity);

            await _context.SaveChangesAsync(token);

            return result.Entity;
        }

        public virtual async Task<bool> DeleteById(int id, CancellationToken token)
        {
            var entity = await GetById(id, token);

            _context.Remove<T>(entity);

            return true;
        }

        public virtual bool Delete(T entity, CancellationToken token)
        {
            _context.Remove<T>(entity);

            return true;
        }
    }
}
