﻿using SuperMegaHyperPuperShop.BLL.DTO;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface ITestService
    {
        Task<PersonDto> Create(PersonDto person);
    }
}
