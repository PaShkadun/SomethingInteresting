namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderItemEntity
    {
#nullable disable
        public ItemEntity Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemCount { get; set; }
        public int OrderHistoryId { get; set; }
        public int OrderInfoId { get; set; }
    }
}
