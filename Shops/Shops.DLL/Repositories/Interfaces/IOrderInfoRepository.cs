using SuperMegaHyperPuperShop.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IOrderInfoRepository : IGenericRepository<OrderInfoEntity>
    {
        Task<IEnumerable<OrderInfoEntity>> GetAllByPerson(string personId, CancellationToken token);
    }
}
