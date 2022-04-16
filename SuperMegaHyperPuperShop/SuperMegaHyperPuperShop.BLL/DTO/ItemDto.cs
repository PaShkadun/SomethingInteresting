using System;
namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class ItemDto
    {
#nullable disable
        public CategoryDto Category { get; set; }
        public string Name { get; set; }
#nullable enable
        public int Id { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
