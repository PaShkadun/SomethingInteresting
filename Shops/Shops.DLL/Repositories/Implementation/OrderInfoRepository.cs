using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Datas;
using SuperMegaHyperPuperShop.DAL.Entities;
using SuperMegaHyperPuperShop.DAL.Repositories.Implementation;
using SuperMegaHyperPuperShop.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shops.DLL.Repositories.Implementation
{
    public class OrderInfoRepository : GenericRepository<OrderInfoEntity>, IOrderInfoRepository
    {
        public OrderInfoRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderInfoEntity>> GetAllByPerson(string personId, CancellationToken token)
        {
            var result = await _context.OrderInfos.Where(x => x.PersonId == personId).ToListAsync(token);

            return result;
        }
    }
}
