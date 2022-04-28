using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderHistoryService _service;
        private readonly IOrderInfoService _infoService;
        private readonly IOrderItemService _itemService;

        public OrderHistoryController(IMapper mapper, 
                                      IOrderHistoryService service,
                                      IOrderInfoService infoService,
                                      IOrderItemService itemService)
        {
            _mapper = mapper;
            _service = service;
            _infoService = infoService;
            _itemService = itemService;
        }

        [HttpPost("create")]
        public async Task<OrderHistoryModel> Add(OrderHistoryModel model, CancellationToken token)
        {
            model.OrderItem = null;
            var orderHistory = _mapper.Map<OrderHistoryModel>(await _service.Add(_mapper.Map<OrderHistoryDto>(model), token));

            return orderHistory;
        }

        [HttpDelete("delete")]
        public async Task<OrderHistoryModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<OrderHistoryModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<OrderHistoryModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<OrderHistoryModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<OrderHistoryModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<OrderHistoryModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<OrderHistoryModel> Update(OrderHistoryModel model, CancellationToken token)
        {
            var dto = _mapper.Map<OrderHistoryDto>(model);

            return _mapper.Map<OrderHistoryModel>(await _service.Update(dto, token));
        }
    }
}
