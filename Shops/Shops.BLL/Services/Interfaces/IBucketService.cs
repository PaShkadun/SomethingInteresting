using SuperMegaHyperPuperShop.BLL.DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface IBucketService : IGenericService<BucketDto>
    {
        Task<IEnumerable<BucketDto>> GetAllByPerson(string personId, CancellationToken token);
        Task<bool> RemoveRange(IEnumerable<BucketDto> ids, CancellationToken token);
    }
}
