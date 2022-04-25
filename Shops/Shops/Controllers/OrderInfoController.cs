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
    public class OrderInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderInfoService _service;

        public OrderInfoController(IMapper mapper, IOrderInfoService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<OrderInfoModel> Add(OrderInfoModel model, CancellationToken token)
        {
            var dto = _mapper.Map<OrderInfoDto>(model);

            return _mapper.Map<OrderInfoModel>(await _service.Add(dto, token));
        }

        [HttpDelete("delete")]
        public async Task<OrderInfoModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<OrderInfoModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<OrderInfoModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<OrderInfoModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<OrderInfoModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<OrderInfoModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<OrderInfoModel> Update(OrderInfoModel model, CancellationToken token)
        {
            var dto = _mapper.Map<OrderInfoDto>(model);

            return _mapper.Map<OrderInfoModel>(await _service.Update(dto, token));
        }

        [HttpGet("getByPerson")]
        public async Task<IEnumerable<OrderInfoModel>> GetByPerson(string personId, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<OrderInfoModel>>(await _service.GetAllByPerson(personId, token));
        }
    }
}
