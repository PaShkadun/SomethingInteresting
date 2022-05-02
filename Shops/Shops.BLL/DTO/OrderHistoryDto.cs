using System;
using System.Collections.Generic;

namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class OrderHistoryDto
    {
#nullable disable
        public virtual IEnumerable<OrderItemDto> OrderItem { get; set; }
        public virtual OrderInfoDto OrderInfo { get; set; }
#nullable enable
        public int Id { get; set; }
        public int OrderInfoId { get; set; }
        public DateTime Date { get; set; }
    }
}
