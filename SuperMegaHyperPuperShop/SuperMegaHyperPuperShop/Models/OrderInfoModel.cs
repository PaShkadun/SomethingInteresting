using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class OrderInfoModel
    {
#nullable disable
        public PersonModel Person { get; set; }
        public string DeliveryAddress { get; set; }
#nullable enable
        public int PersonId { get; set; }
        public int Id { get; set; }
    }
}
