using SuperMegaHyperPuperShop.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface IBookmarkService : IGenericService<BookmarkDto>
    {
        Task<IEnumerable<BookmarkDto>> GetAllByItem(int itemId, CancellationToken token);
        Task<IEnumerable<BookmarkDto>> GetAllByPerson(string personId, CancellationToken token);
    }
}
