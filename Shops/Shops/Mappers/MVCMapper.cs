using AutoMapper;
using GenericLayer;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.Models;

namespace SuperMegaHyperPuperShop.Mappers
{
    public class MVCMapper : Profile
    {
        public MVCMapper()
        {
            CreateMap<PersonModel, PersonDto>().ReverseMap();
            CreateMap<BookmarkDto, BookmarkModel>().ReverseMap();
            CreateMap<BucketDto, BucketModel>().ReverseMap();
            CreateMap<CategoryDto, CategoryModel>().ReverseMap();
            CreateMap<ItemDto, ItemModel>().ReverseMap();
            CreateMap<OrderHistoryDto, OrderHistoryModel>().ReverseMap();
            CreateMap<OrderInfoDto, OrderInfoModel>().ReverseMap();
            CreateMap<OrderItemDto, OrderItemModel>().ReverseMap();
            CreateMap<PermissionDto, PermissionModel>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));
        }
    }
}
