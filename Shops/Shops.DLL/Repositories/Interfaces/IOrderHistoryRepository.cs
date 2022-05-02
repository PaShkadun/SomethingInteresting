using SuperMegaHyperPuperShop.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IOrderHistoryRepository : IGenericRepository<OrderHistoryEntity>
    {
        Task<IEnumerable<OrderHistoryEntity>> GetByPerson(string personId, CancellationToken token);
    }
}
