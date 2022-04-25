using System;

namespace SuperMegaHyperPuperShop.Models
{
    public class BookmarkModel
    {
#nullable disable
        public PersonModel Person { get; set; }
        public ItemModel Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public string PersonId { get; set; }
        public int ItemId { get; set; }
    }
}
