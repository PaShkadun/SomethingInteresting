using Shops.DLL.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Shops.DLL.Repositories.Interfaces;
using Shops.DLL.Repositories.Implementations;
using Shops.BLL.Services.Implementations;
using Shops.BLL.Services.Interfaces;

namespace Shops.DLL
{
    public static class IoC
    {
        public static void Injections(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IShoppingMallService, ShoppingMallService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
