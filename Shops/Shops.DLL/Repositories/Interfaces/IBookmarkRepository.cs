using SuperMegaHyperPuperShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Repositories.Interfaces
{
    public interface IBookmarkRepository : IGenericRepository<BookmarkEntity>
    {
        Task<IEnumerable<BookmarkEntity>> GetAllByItem(int itemId, CancellationToken token);
        Task<IEnumerable<BookmarkEntity>> GetAllByPersonId(string personId, CancellationToken token);
    }
}
