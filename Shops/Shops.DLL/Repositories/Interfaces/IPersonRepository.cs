using SuperMegaHyperPuperShop.DAL.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IPersonRepository : IGenericRepository<PersonEntity>
    {
        Task<PersonEntity> GetById(string id, CancellationToken token);
    }
}
