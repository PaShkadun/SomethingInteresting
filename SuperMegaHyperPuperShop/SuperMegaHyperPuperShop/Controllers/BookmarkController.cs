using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.Models;

namespace SuperMegaHyperPuperShop.Controllers
{
    public class BookmarkController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<BookmarkDto> _service;

        public BookmarkController(IMapper mapper, IGenericService<BookmarkDto> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost("/create")]
        public async Task<BookmarkModel> Add(BookmarkModel model, CancellationToken token)
        {
            var dto = _mapper.Map<BookmarkDto>(model);

            return _mapper.Map<BookmarkModel>(await _service.Add(dto, token));
        }
    }
}
