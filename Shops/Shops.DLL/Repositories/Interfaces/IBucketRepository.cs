using SuperMegaHyperPuperShop.DAL.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IBucketRepository : IGenericRepository<BucketEntity>
    {
        Task<IEnumerable<BucketEntity>> GetAllByPerson(string personId, CancellationToken token);
    }
}
