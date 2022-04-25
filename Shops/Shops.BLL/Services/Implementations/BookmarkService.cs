using AutoMapper;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.BLL.Services.Implementations
{
    public class BookmarkService : GenericService<BookmarkDto, BookmarkEntity>, IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public BookmarkService(IBookmarkRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _bookmarkRepository = repository;
        }

        public async Task<IEnumerable<BookmarkDto>> GetAllByItem(int itemId, CancellationToken token)
        {
            var result = await _bookmarkRepository.GetAllByItem(itemId, token);

            return _mapper.Map<IEnumerable<BookmarkDto>>(result);
        }

        public async Task<IEnumerable<BookmarkDto>> GetAllByPerson(string personId, CancellationToken token)
        {
            var result = await _bookmarkRepository.GetAllByPersonId(personId, token);

            return _mapper.Map<IEnumerable<BookmarkDto>>(result);
        }
    }
}
