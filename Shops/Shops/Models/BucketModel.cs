using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class BucketModel
    {
#nullable disable
        public ItemModel Item { get; set; }
        public PersonModel Person { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string PersonId { get; set; }
    }
}
