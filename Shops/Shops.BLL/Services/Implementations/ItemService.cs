using AutoMapper;
using GenericLayer;
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
    public class ItemService : GenericService<ItemDto, ItemEntity>, IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _itemRepository = repository;
        }

        public async Task<PagedList<ItemDto>> GetByCategory(int id, SortingData sorting, CancellationToken token)
        {
            var result = await _itemRepository.GetByCategory(id, sorting, token);

            return _mapper.Map<PagedList<ItemDto>>(result);
        }
    }
}
