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
    public class OrderItemService : GenericService<OrderItemDto, OrderItemEntity>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _orderItemRepository = repository;
        }

        public async Task<IEnumerable<OrderItemDto>> GetAllByOrderInfo(int orderInfoId, CancellationToken token)
        {
            var result = await _orderItemRepository.GetAllByOrderInfo(orderInfoId, token);

            return _mapper.Map<IEnumerable<OrderItemDto>>(result);
        }
    }
}
