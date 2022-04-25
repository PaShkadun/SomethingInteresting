using AutoMapper;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.BLL.Services.Implementations
{
    public class BucketService : GenericService<BucketDto, BucketEntity>, IBucketService
    {
        private readonly IBucketRepository _bucketRepository;

        public BucketService(IBucketRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _bucketRepository = repository;
        }

        public async Task<IEnumerable<BucketDto>> GetAllByPerson(string personId, CancellationToken token)
        {
            var result = await _bucketRepository.GetAllByPerson(personId, token);

            return _mapper.Map<IEnumerable<BucketDto>>(result);
        }
    }
}
