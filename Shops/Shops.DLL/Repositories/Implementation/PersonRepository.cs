using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Implementation;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.DLL.Repositories.Implementation
{
    public class PersonRepository : GenericRepository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }

        public async Task<PersonEntity> GetById(string id, CancellationToken token)
        {
            var result = await _context.Persons.Include(x => x.Permission).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
