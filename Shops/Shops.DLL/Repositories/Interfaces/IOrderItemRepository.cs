using SuperMegaHyperPuperShop.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItemEntity>
    {
        Task<IEnumerable<OrderItemEntity>> GetAllByOrderInfo(int orderInfoId, CancellationToken token);
        Task<IEnumerable<OrderItemEntity>> AddRange(IEnumerable<OrderItemEntity> entities, CancellationToken token);
    }
}
