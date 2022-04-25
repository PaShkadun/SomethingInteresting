using AutoMapper;
using GenericLayer;
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
    public class ItemController : RootController<ItemModel>
    {
        private readonly IMapper _mapper;
        private readonly IItemService _service;

        public ItemController(IMapper mapper, IItemService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ItemModel> Add(ItemModel model, CancellationToken token)
        {
            var dto = _mapper.Map<ItemDto>(model);

            return _mapper.Map<ItemModel>(await _service.Add(dto, token));
        }

        [HttpDelete("delete")]
        public async Task<ItemModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<ItemModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<ItemModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<ItemModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<ItemModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<ItemModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<ItemModel> Update(ItemModel model, CancellationToken token)
        {
            var dto = _mapper.Map<ItemDto>(model);

            return _mapper.Map<ItemModel>(await _service.Update(dto, token));
        }

        [HttpGet("getByCategory")]
        public async Task<IEnumerable<ItemModel>> GetByCategory([FromQuery] int categoryId, [FromQuery] SortingData sorting, CancellationToken token)
        {
            var result = _mapper.Map<PagedList<ItemModel>>(await _service.GetByCategory(categoryId, sorting, token));

            SetHeader(result);

            return result.Entities;
        }
    }
}
