using System;

namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class BookmarkDto
    {
#nullable disable
        public PersonDto Person { get; set; }
        public ItemDto Item { get; set; }
#nullable enable
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ItemId { get; set; }
    }
}
