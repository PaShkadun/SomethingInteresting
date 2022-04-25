using SuperMegaHyperPuperShop.DAL.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
        Task<CategoryEntity> GetByName(string name, CancellationToken token);
    }
}
