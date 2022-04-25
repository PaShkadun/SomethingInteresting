using AutoMapper;
using Shops.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;

namespace Shops.BLL.Services.Implementations
{
    public class PermissionService : GenericService<PermissionDto, PermissionEntity>, IPermissionService
    {
        public PermissionService(IPermissionRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
