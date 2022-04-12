using System;

namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderHistoryEntity
    {
#nullable disable
        public PersonEntity Person { get; set; }
        public OrderItemEntity OrderItem { get; set; }
#nullable enable
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int OrderItemId { get; set; }
        public DateTime Date { get; set; }
    }
}
