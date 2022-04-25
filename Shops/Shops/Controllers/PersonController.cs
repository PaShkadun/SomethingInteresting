using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shops.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : RootController<PersonModel>
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _service;

        public PersonController(IMapper mapper, IPersonService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<PersonModel> Add(PersonModel person, CancellationToken token)
        {
            var result = await _service.Add(_mapper.Map<PersonDto>(person), token);

            return _mapper.Map<PersonModel>(result);
        }

        [HttpGet("getById")]
        public async Task<PersonModel> GetById(string id, CancellationToken token)
        {
            var result = await _service.GetById(id, token);

            return _mapper.Map<PersonModel>(result);
        }
    }
}
