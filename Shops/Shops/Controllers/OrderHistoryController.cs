using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;
using System;
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
        private readonly IBucketService _bucketService;

        public OrderHistoryController(IMapper mapper, 
                                      IOrderHistoryService service,
                                      IOrderInfoService infoService,
                                      IOrderItemService itemService,
                                      IBucketService bucketService)
        {
            _mapper = mapper;
            _service = service;
            _infoService = infoService;
            _itemService = itemService;
            _bucketService = bucketService;
        }

        [HttpPost("create")]
        public async Task<OrderHistoryModel> Add([FromQuery] int[] itemsIds, [FromQuery] int[] counts, [FromBody] OrderHistoryModel model, CancellationToken token)
        {
            model.OrderItem = null;
            model.OrderInfo.Date = DateTime.Now;

            var orderHistory = _mapper.Map<OrderHistoryModel>(await _service.Add(_mapper.Map<OrderHistoryDto>(model), token));

            var items = new List<OrderItemModel>();

            for (var i = 0; i < itemsIds.Length; i++)
            {
                items.Add(
                    new OrderItemModel
                    {
                        OrderHistoryId = orderHistory.Id,
                        ItemId = itemsIds[i],
                        ItemCount = counts[i]
                    });
            }

            var resultItems = _mapper.Map<IEnumerable<OrderItemModel>>(await _itemService.AddRange(_mapper.Map<IEnumerable<OrderItemDto>>(items), token));
            orderHistory.OrderItem = resultItems;


            await _bucketService.RemoveRange(await _bucketService.GetAllByPerson(orderHistory.OrderInfo.PersonId, token), token);

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

        [HttpGet("getByPerson")]
        public async Task<IEnumerable<OrderHistoryModel>> GetByPerson(string personId, CancellationToken token)
        {
            var result = await _service.GetByPerson(personId, token);

            return _mapper.Map<IEnumerable<OrderHistoryModel>>(result);
        }
    }
}
