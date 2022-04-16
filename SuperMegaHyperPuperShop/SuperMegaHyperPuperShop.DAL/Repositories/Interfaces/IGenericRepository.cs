using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> Get(CancellationToken token);
        Task<T> GetById(int id, CancellationToken token);
        Task<T> Add(T entity, CancellationToken token);
        Task<T> Update(T entity, CancellationToken token);
        Task<bool> DeleteById(int id, CancellationToken token);
        bool Delete(T entity, CancellationToken token);
    }
}
