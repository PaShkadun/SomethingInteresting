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
    public class BucketController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBucketService _service;

        public BucketController(IMapper mapper, IBucketService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<BucketModel> Add(BucketModel model, CancellationToken token)
        {
            var dto = _mapper.Map<BucketDto>(model);

            return _mapper.Map<BucketModel>(await _service.Add(dto, token));
        }

        [HttpDelete("delete")]
        public async Task<BucketModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<BucketModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<BucketModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<BucketModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<BucketModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<BucketModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<BucketModel> Update(BucketModel model, CancellationToken token)
        {
            var dto = _mapper.Map<BucketDto>(model);

            return _mapper.Map<BucketModel>(await _service.Update(dto, token));
        }

        [HttpGet("getByPerson")]
        public async Task<IEnumerable<BucketModel>> GetByPerson(string personId, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<BucketModel>>(await _service.GetAllByPerson(personId, token));
        }
    }
}
