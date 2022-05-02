using GenericLayer;
using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Implementation;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.DLL.Repositories.Implementation
{
    public class ItemRepository : GenericRepository<ItemEntity>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context)
        {
        }

        public async Task<PagedList<ItemEntity>> GetByCategory(int id, SortingData sorting, CancellationToken token)
        {
            var query = _context.Items.Where(x => x.CategoryId == id).Include(x => x.Category);
            var result = await PagedList<ItemEntity>.ToPagedList(query, sorting, token);

            return result;
        }

        public override Task<ItemEntity> GetById(int id, CancellationToken token)
        {
            var query = _context.Items.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id, token);

            return query;
        }
    }
}
