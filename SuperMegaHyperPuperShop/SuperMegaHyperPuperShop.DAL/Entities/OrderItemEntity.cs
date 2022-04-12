namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderItemEntity
    {
#nullable disable
        public OrderInfoEntity OrderInfo { get; set; }
        public ItemEntity Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemCount { get; set; }
    }
}
