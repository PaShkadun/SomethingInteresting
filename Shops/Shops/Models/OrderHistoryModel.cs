using System;
using System.Collections.Generic;

namespace SuperMegaHyperPuperShop.Models
{
    public class OrderHistoryModel
    {
#nullable disable
        public virtual IEnumerable<OrderItemModel> OrderItem { get; set; }
        public virtual OrderInfoModel OrderInfo { get; set; }
#nullable enable
        public int Id { get; set; }
        public int OrderInfoId { get; set; }
        public DateTime Date { get; set; }
    }
}
