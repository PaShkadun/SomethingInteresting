using AutoMapper;
using Shops.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
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
    public class PersonService : GenericService<PersonDto, PersonEntity>, IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _personRepository = repository;
        }

        public async Task<PersonDto> GetById(string id, CancellationToken token)
        {
            var result = await _personRepository.GetById(id, token);

            return _mapper.Map<PersonDto>(result);
        }
    }
}
