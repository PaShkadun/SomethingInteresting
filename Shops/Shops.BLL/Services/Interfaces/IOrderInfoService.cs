using SuperMegaHyperPuperShop.BLL.DTO;
using SuperMegaHyperPuperShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.BLL.Services.Interfaces
{
    public interface IOrderInfoService : IGenericService<OrderInfoDto>
    {
        Task<IEnumerable<OrderInfoDto>> GetAllByPerson(string personId, CancellationToken token);
    }
}
