using GenericLayer;
using SuperMegaHyperPuperShop.BLL.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface IItemService : IGenericService<ItemDto>
    {
        Task<PagedList<ItemDto>> GetByCategory(int id, SortingData sorting, CancellationToken token);
    }
}
