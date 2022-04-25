using SuperMegaHyperPuperShop.BLL.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface ICategoryService : IGenericService<CategoryDto>
    {
        Task<CategoryDto> GetByName(string name, CancellationToken token);
    }
}
