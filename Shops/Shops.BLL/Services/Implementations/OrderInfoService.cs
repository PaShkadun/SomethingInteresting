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
    public class OrderInfoService : GenericService<OrderInfoDto, OrderInfoEntity>, IOrderInfoService
    {
        private readonly IOrderInfoRepository _orderInfoRepository;

        public OrderInfoService(IOrderInfoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _orderInfoRepository = repository;
        }

        public async Task<IEnumerable<OrderInfoDto>> GetAllByPerson(string personId, CancellationToken token)
        {
            var result = await _orderInfoRepository.GetAllByPerson(personId, token);

            return _mapper.Map<IEnumerable<OrderInfoDto>>(result);
        }
    }
}
