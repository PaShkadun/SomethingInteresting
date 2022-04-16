using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            service.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
