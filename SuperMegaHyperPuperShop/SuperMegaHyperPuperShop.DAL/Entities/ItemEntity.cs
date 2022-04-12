namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class ItemEntity
    {
#nullable disable
        public CategoryEntity Category { get; set; }
        public string Name { get; set; }
#nullable enable
        public int Id { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
