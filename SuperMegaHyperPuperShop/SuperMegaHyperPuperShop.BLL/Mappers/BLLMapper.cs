using AutoMapper;
using SuperMegaHyperPuperShop.BLL.Models;
using SuperMegaHyperPuperShop.DAL.Models;

namespace SuperMegaHyperPuperShop.BLL.Mappers
{
    public class BLLMapper : Profile
    {
        public BLLMapper()
        {
            CreateMap<PersonDto, PersonEntity>().ReverseMap();
        }
    }
}
