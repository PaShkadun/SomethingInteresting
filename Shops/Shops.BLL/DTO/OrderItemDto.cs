using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class OrderItemDto
    {
#nullable disable
        public ItemDto Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public int OrderHistoryId { get; set; }
        public int OrderInfoId { get; set; }
    }
}
