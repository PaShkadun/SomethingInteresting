using SuperMegaHyperPuperShop.DAL.Entities;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<PersonEntity> Create(PersonEntity person);
    }
}
