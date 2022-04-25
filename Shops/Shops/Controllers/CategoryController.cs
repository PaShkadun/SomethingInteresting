using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public CategoryController(IMapper mapper, ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<CategoryModel> Add(CategoryModel model, CancellationToken token)
        {
            var dto = _mapper.Map<CategoryDto>(model);

            return _mapper.Map<CategoryModel>(await _service.Add(dto, token));
        }

        [HttpDelete("delete")]
        public async Task<CategoryModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<CategoryModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<CategoryModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<CategoryModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<CategoryModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<CategoryModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<CategoryModel> Update(CategoryModel model, CancellationToken token)
        {
            var dto = _mapper.Map<CategoryDto>(model);

            return _mapper.Map<CategoryModel>(await _service.Update(dto, token));
        }

        [HttpGet("getByName")]
        public async Task<CategoryModel> GetByName(string name, CancellationToken token)
        {
            var result = await _service.GetByName(name, token);

            return _mapper.Map<CategoryModel>(result);
        }
    }
}
