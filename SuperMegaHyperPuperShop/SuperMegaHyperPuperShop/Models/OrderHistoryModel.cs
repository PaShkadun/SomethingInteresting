using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class OrderHistoryModel
    {
#nullable disable
        public PersonModel Person { get; set; }
        public OrderItemModel OrderItem { get; set; }
#nullable enable
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int OrderItemId { get; set; }
        public DateTime Date { get; set; }
    }
}
