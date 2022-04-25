using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;

namespace SuperMegaHyperPuperShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookmarkController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookmarkService _service;

        public BookmarkController(IMapper mapper, IBookmarkService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("create")]
        public async Task<BookmarkModel> Add(BookmarkModel model, CancellationToken token)
        {
            var dto = _mapper.Map<BookmarkDto>(model);

            return _mapper.Map<BookmarkModel>(await _service.Add(dto, token));
        }

        [HttpDelete("delete")]
        public async Task<BookmarkModel> Delete(int id, CancellationToken token)
        {
            return _mapper.Map<BookmarkModel>(await _service.DeleteById(id, token));
        }

        [HttpGet("getAll")]
        public async Task<IEnumerable<BookmarkModel>> GetAll(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<BookmarkModel>>(await _service.Get(token));
        }

        [HttpGet("getById")]
        public async Task<BookmarkModel> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<BookmarkModel>(await _service.GetById(id, token));
        }

        [HttpPut("update")]
        public async Task<BookmarkModel> Update(BookmarkModel model, CancellationToken token)
        {
            var dto = _mapper.Map<BookmarkDto>(model);

            return _mapper.Map<BookmarkModel>(await _service.Update(dto, token));
        }

        [HttpGet("getByItem")]
        public async Task<IEnumerable<BookmarkModel>> GetByItem(int itemId, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<BookmarkModel>>(await _service.GetAllByItem(itemId, token));
        }

        [HttpPost("getByPerson")]
        public async Task<IEnumerable<BookmarkModel>> GetByPerson(string personId, CancellationToken token)
        {
            return _mapper.Map<IEnumerable<BookmarkModel>>(await _service.GetAllByPerson(personId, token));
        }
    }
}
