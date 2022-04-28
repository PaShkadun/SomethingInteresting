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
    public class BookmarkRepository : GenericRepository<BookmarkEntity>, IBookmarkRepository
    {
        public BookmarkRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookmarkEntity>> GetAllByItem(int itemId, CancellationToken token)
        {
            var result = await _context.Bookmarks.Where(x => x.ItemId == itemId).ToListAsync(token);

            return result;
        }

        public async Task<IEnumerable<BookmarkEntity>> GetAllByPersonId(string personId, CancellationToken token)
        {
            var result = await _context.Bookmarks.AsNoTracking().Include(x => x.Item).Where(x => x.PersonId == personId).ToListAsync(token);

            return result;
        }
    }
}
