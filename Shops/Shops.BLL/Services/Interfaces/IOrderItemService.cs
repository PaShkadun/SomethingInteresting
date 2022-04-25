using SuperMegaHyperPuperShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface IOrderItemService : IGenericService<OrderItemDto>
    {
        Task<IEnumerable<OrderItemDto>> GetAllByOrderInfo(int orderIndoId, CancellationToken token);
    }
}
