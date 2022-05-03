using System;

namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderInfoEntity
    {
#nullable disable
        public PersonEntity Person { get; set; }
        public string DeliveryAddress { get; set; }
        public string PersonId { get; set; }
#nullable enable
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
