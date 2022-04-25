using GenericLayer;
using SuperMegaHyperPuperShop.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IItemRepository : IGenericRepository<ItemEntity>
    {
        Task<PagedList<ItemEntity>> GetByCategory(int id, SortingData sorting, CancellationToken token);
    }
}
