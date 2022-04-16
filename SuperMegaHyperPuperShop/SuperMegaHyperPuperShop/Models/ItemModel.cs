using System;
namespace SuperMegaHyperPuperShop.Models
{
    public class ItemModel
    {
#nullable disable
        public CategoryModel Category { get; set; }
        public string Name { get; set; }
#nullable enable
        public int Id { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
