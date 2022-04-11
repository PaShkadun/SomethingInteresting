using AutoMapper;
using SuperMegaHyperPuperShop.BLL.Models;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.Models;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Implementations
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _repository;
        private readonly IMapper _mapper;

        public TestService(ITestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PersonDto> Create(PersonDto person)
        {
            var entity = await _repository.Create(_mapper.Map<PersonEntity>(person));

            return _mapper.Map<PersonDto>(entity);
        }
    }
}
