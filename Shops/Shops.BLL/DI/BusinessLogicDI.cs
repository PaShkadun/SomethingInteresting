using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shops.BLL.Services.Implementations;
using Shops.BLL.Services.Interfaces;
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
            service.AddScoped<IGenericService<PermissionDto>, GenericService<PermissionDto, PermissionEntity>>();
            service.AddScoped<IGenericService<PersonDto>, GenericService<PersonDto, PersonEntity>>();

            service.AddScoped<IBookmarkService, BookmarkService>();
            service.AddScoped<IBucketService, BucketService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<IOrderHistoryService, OrderHistoryService>();
            service.AddScoped<IOrderInfoService, OrderInfoService>();
            service.AddScoped<IOrderItemService, OrderItemService>();
            service.AddScoped<IItemService, ItemService>();
            service.AddScoped<IPermissionService, PermissionService>();
            service.AddScoped<IPersonService, PersonService>();

            service.AddDataLogic(config);
        }
    }
}
