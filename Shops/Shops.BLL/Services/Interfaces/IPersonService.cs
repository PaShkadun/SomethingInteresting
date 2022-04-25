using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.BLL.Services.Interfaces
{
    public interface IPersonService : IGenericService<PersonDto>
    {
        Task<PersonDto> GetById(string id, CancellationToken token);
    }
}
