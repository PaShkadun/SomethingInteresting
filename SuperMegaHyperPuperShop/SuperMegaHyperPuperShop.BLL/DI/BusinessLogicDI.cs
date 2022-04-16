using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.BLL.Services.Implementations;
using SuperMegaHyperPuperShop.BLL.Services.Interfaces;
using SuperMegaHyperPuperShop.DAL.DI;
using SuperMegaHyperPuperShop.DAL.Entities;

namespace SuperMegaHyperPuperShop.BLL.DI
{
    public static class BusinessLogicDI
    {
        public static void AddBusinessLogic(this IServiceCollection service, IConfiguration config)
        {
            service.AddScoped<ITestService, TestService>();

            service.AddScoped<IGenericService<BookmarkDto>, GenericService<BookmarkDto, BookmarkEntity>>();
            service.AddScoped<IGenericService<BucketDto>, GenericService<BucketDto, BucketEntity>>();
            service.AddScoped<IGenericService<CategoryDto>, GenericService<CategoryDto, CategoryEntity>>();
            service.AddScoped<IGenericService<ItemDto>, GenericService<ItemDto, ItemEntity>>();
            service.AddScoped<IGenericService<OrderHistoryDto>, GenericService<OrderHistoryDto, OrderHistoryEntity>>();
            service.AddScoped<IGenericService<OrderInfoDto>, GenericService<OrderInfoDto, OrderInfoEntity>>();
            service.AddScoped<IGenericService<OrderItemDto>, GenericService<OrderItemDto, OrderItemEntity>>();
            service.AddScoped<IGenericService<PermissionDto>, GenericService<PermissionDto, PermisionEntity>>();
            service.AddScoped<IGenericService<PersonDto>, GenericService<PersonDto, PersonEntity>>();

            service.AddDataLogic(config);
        }
    }
}
