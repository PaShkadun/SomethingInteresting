using AutoMapper;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.BLL.Services.Implementations
{
    public class OrderHistoryService : GenericService<OrderHistoryDto, OrderHistoryEntity>, IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderHistoryService(IOrderHistoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _orderHistoryRepository = repository;
        }
    }
}
