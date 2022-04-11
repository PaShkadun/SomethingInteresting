using System;

namespace SuperMegaHyperPuperShop.DAL.Models
{
    public class PersonEntity
    {
#nullable disable
        public string Name { get; set; }
#nullable enable
        public int Id { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}
