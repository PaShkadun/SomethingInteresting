using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class OrderHistoryDto
    {
#nullable disable
        public PersonDto Person { get; set; }
        public OrderItemDto OrderItem { get; set; }
#nullable enable
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int OrderItemId { get; set; }
        public DateTime Date { get; set; }
    }
}
