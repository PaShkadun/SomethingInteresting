using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;

namespace SuperMegaHyperPuperShop.BLL.Services.Implementations
{
    public class GenericService<Dto, Entity> : IGenericService<Dto> where Entity : class where Dto : class
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Dto> Add(Dto entity, CancellationToken token)
        {
            var result = await _repository.Add(_mapper.Map<Entity>(entity), token);

            return _mapper.Map<Dto>(result);
        }

        public bool Delete(Dto entity, CancellationToken token)
        {
            return _repository.Delete(_mapper.Map<Entity>(entity), token);
        }

        public Task<bool> DeleteById(int id, CancellationToken token)
        {
            return _repository.DeleteById(id, token);
        }

        public async Task<IEnumerable<Dto>> Get(CancellationToken token)
        {
            return _mapper.Map<IEnumerable<Dto>>(await _repository.Get(token));
        }

        public async Task<Dto> GetById(int id, CancellationToken token)
        {
            return _mapper.Map<Dto>(await _repository.GetById(id, token));
        }

        public async Task<Dto> Update(Dto entity, CancellationToken token)
        {
            var model = _mapper.Map<Entity>(entity);

            return _mapper.Map<Dto>(await _repository.Update(model, token));
        }
    }
}
