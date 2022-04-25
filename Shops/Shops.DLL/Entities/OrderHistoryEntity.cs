using System;
using System.Collections.Generic;

namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderHistoryEntity
    {
#nullable disable
        public virtual List<OrderItemEntity> OrderItem { get; set; }
        public virtual OrderInfoEntity OrderInfo { get; set; }
#nullable enable
        public int Id { get; set; }
        public int OrderInfoId { get; set; }
        public DateTime Date { get; set; }
    }
}
