using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shops.DLL.Repositories.Implementation;
using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Repositories.Implementation;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;

namespace SuperMegaHyperPuperShop.DAL.DI
{
    public static class DataLogicDI
    {
        public static void AddDataLogic(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<ITestRepository, TestRepository>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            service.AddScoped<IBookmarkRepository, BookmarkRepository>();
            service.AddScoped<IBucketRepository, BucketRepository>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
            service.AddScoped<IItemRepository, ItemRepository>();
            service.AddScoped<IOrderHistoryRepository, OrderHistoryRepository>();
            service.AddScoped<IOrderInfoRepository, OrderInfoRepository>();
            service.AddScoped<IOrderItemRepository, OrderItemRepository>();
            service.AddScoped<IPersonRepository, PersonRepository>();
            service.AddScoped<IPermissionRepository, PermissionRepository>();

            service.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
