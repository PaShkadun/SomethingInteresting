using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class OrderItemModel
    {
#nullable disable
        public ItemModel Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemCount { get; set; }
        public int OrderHistoryId { get; set; }
        public int OrderInfoId { get; set; }
    }
}
