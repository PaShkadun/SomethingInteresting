using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class BucketDto
    {
#nullable disable
        public ItemDto Item { get; set; }
        public PersonDto Person { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int PersonId { get; set; }
    }
}
