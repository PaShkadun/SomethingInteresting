using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Implementation;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;

namespace Shops.DLL.Repositories.Implementation
{
    public class PermissionRepository : GenericRepository<PermissionEntity>, IPermissionRepository
    {
        public PermissionRepository(DataContext context) : base(context)
        {
        }
    }
}
