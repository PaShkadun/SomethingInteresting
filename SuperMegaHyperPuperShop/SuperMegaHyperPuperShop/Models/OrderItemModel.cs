using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class OrderItemModel
    {
#nullable disable
        public OrderInfoModel OrderInfo { get; set; }
        public ItemModel Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemCount { get; set; }
    }
}
