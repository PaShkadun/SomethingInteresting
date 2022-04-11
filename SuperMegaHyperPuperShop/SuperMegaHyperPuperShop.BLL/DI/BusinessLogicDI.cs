using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.DI;

namespace SuperMegaHyperPuperShop.BLL.DI
{
    public static class BusinessLogicDI
    {
        public static void AddBusinessLogic(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<ITestService, TestService>();

            service.AddDataLogic(config);
        }
    }
}
