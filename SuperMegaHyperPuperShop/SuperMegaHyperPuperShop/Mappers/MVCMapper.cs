using AutoMapper;
using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.Models;

namespace SuperMegaHyperPuperShop.Mappers
{
    public class MVCMapper : Profile
    {
        public MVCMapper()
        {
            CreateMap<PersonModel, PersonDto>().ReverseMap();
        }
    }
}
