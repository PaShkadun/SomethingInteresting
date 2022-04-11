using AutoMapper;
using SuperMegaHyperPuperShop.Models;
using SuperMegaHyperPuperShop.BLL.Models;

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
