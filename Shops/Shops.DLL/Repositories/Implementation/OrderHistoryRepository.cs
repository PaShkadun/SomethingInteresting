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
    public class OrderHistoryRepository : GenericRepository<OrderHistoryEntity>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(DataContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<OrderHistoryEntity>> Get(CancellationToken token)
        {
            return await _context.OrderHistories
                           .AsNoTracking()
                           .Include(x => x.OrderInfo)
                           .ThenInclude(x => x.Person)
                           .Include(x => x.OrderItem)
                           .ToListAsync(token);
        }
    }
}
