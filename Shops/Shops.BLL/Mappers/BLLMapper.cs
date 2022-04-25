using AutoMapper;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.DAL.Entities;

namespace SuperMegaHyperPuperShop.BLL.Mappers
{
    public class BLLMapper : Profile
    {
        public BLLMapper()
        {
            CreateMap<BookmarkDto, BookmarkEntity>().ReverseMap();
            CreateMap<BucketDto, BucketEntity>().ReverseMap();
            CreateMap<CategoryDto, CategoryEntity>().ReverseMap();
            CreateMap<ItemDto, ItemEntity>().ReverseMap();
            CreateMap<OrderHistoryDto, OrderHistoryEntity>().ReverseMap();
            CreateMap<OrderInfoDto, OrderInfoEntity>().ReverseMap();
            CreateMap<OrderItemDto, OrderItemEntity>().ReverseMap();
            CreateMap<PermissionDto, PermissionEntity>().ReverseMap();
            CreateMap<PersonDto, PersonEntity>().ReverseMap();
        }
    }
}
