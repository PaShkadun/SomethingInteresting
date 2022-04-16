using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class OrderItemDto
    {
#nullable disable
        public OrderInfoDto OrderInfo { get; set; }
        public ItemDto Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemCount { get; set; }
    }
}
