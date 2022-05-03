using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class OrderInfoDto
    {
#nullable disable
        public PersonDto Person { get; set; }
        public string DeliveryAddress { get; set; }
        public string PersonId { get; set; }
#nullable enable
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
