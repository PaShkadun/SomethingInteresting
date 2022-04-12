namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class OrderInfoEntity
    {
#nullable disable
        public PersonEntity Person { get; set; }
        public string DeliveryAddress { get; set; }
#nullable enable
        public int PersonId { get; set; }
        public int Id { get; set; }
    }
}
