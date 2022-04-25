namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class BookmarkEntity
    {
#nullable disable
        public PersonEntity Person { get; set; }
        public ItemEntity Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public string PersonId { get; set; }
        public int ItemId { get; set; }
    }
}
