namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderItemEntity
    {
#nullable disable
        public ItemEntity Item { get; set; }
        public OrderHistoryEntity OrderHistory { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public int OrderHistoryId { get; set; }
    }
}
