using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class OrderInfoModel
    {
#nullable disable
        public PersonModel Person { get; set; }
        public string DeliveryAddress { get; set; }
        public string PersonId { get; set; }
#nullable enable
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
