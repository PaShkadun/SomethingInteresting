using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class OrderInfoDto
    {
#nullable disable
        public PersonDto Person { get; set; }
        public string DeliveryAddress { get; set; }
#nullable enable
        public int PersonId { get; set; }
        public int Id { get; set; }
    }
}
