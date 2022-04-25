using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemService _service;

        public OrderItemController(IMapper mapper, IOrderItemService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<OrderItemModel> Add(OrderItemModel model, CancellationToken token)
        {
            var dto = _mapper.Map<OrderItemDto>(model);

            return _mapper.Map<OrderItemModel>(await _service.Add(dto, token));
        }

        [HttpDelete("delete")]
        public async Task<OrderItemModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<OrderItemModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<OrderItemModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<OrderItemModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<OrderItemModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<OrderItemModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<OrderItemModel> Update(OrderItemModel model, CancellationToken token)
        {
            var dto = _mapper.Map<OrderItemDto>(model);

            return _mapper.Map<OrderItemModel>(await _service.Update(dto, token));
        }

        [HttpGet("getByOrderInfo")]
        public async Task<IEnumerable<OrderItemModel>> GetByOrderInfo(int orderInfoId, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<OrderItemModel>>(await _service.GetAllByOrderInfo(orderInfoId, token));
        }
    }
}
