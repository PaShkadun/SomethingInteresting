using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private readonly IBucketService _bucketService;

        public OrderItemController(IMapper mapper, IOrderItemService service, IBucketService bucketService)
        {
            _mapper = mapper;
            _service = service;
            _bucketService = bucketService;
        }

        [HttpPost("create")]
        public async Task<IEnumerable<OrderItemModel>> Add([FromQuery] int orderId, [FromQuery] int[] itemsIds, CancellationToken token)
        {
            var list = new List<OrderItemModel>();
            var idsList = new List<BucketModel>();

            for (var i = 0; i < itemsIds.Length; i++)
            {
                var model = new OrderItemModel { OrderHistoryId = orderId, ItemId = itemsIds[i] };

                var dto = _mapper.Map<OrderItemDto>(model);
                var result = _mapper.Map<OrderItemModel>(await _service.Add(dto, token));

                list.Add(result);
                idsList.Add(new BucketModel { Id = itemsIds[i] });
            }

            await _bucketService.RemoveRange(_mapper.Map<IEnumerable<BucketDto>>(idsList), token);

            return list;
        }

        [HttpPost("createRange")]
        public async Task<IEnumerable<OrderItemModel>> AddRange([FromQuery] string stringAsModel, CancellationToken token)
        {
            var model = stringAsModel.Replace('|', '"');

            var newModel = JsonSerializer.Deserialize<List<OrderItemModel>>(model);

            var dto = _mapper.Map<IEnumerable<OrderItemDto>>(newModel);
            var result = _mapper.Map<IEnumerable<OrderItemModel>>(await _service.AddRange(dto, token));

            return result;
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
