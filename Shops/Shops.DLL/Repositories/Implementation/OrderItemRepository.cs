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
    public class OrderItemRepository : GenericRepository<OrderItemEntity>, IOrderItemRepository
    {
        public OrderItemRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderItemEntity>> GetAllByOrderInfo(int orderInfoId, CancellationToken token)
        {
            var result = await _context.OrderItems.Where(x => x.OrderInfoId == orderInfoId).ToListAsync(token);

            return result;
        }
    }
}
