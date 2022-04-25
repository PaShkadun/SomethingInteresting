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
    public class PermissionController : RootController<PermissionModel>
    {
        private readonly IMapper _mapper;
        private readonly IPermissionService _service;

        public PermissionController(IMapper mapper, IPermissionService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<PermissionModel> Add(PermissionModel person, CancellationToken token)
        {
            var result = await _service.Add(_mapper.Map<PermissionDto>(person), token);

            return _mapper.Map<PermissionModel>(result);
        }
    }
}
