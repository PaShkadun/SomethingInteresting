using AutoMapper;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.BLL.Services.Implementations
{
    public class CategoryService : GenericService<CategoryDto, CategoryEntity>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _categoryRepository = repository;
        }

        public async Task<CategoryDto> GetByName(string name, CancellationToken token)
        {
            var result = await _categoryRepository.GetByName(name, token);

            return _mapper.Map<CategoryDto>(result);
        }
    }
}
