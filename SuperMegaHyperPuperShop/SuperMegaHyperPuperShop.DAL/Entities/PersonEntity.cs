using System;

namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class PersonEntity
    {
#nullable disable
        public string Name { get; set; }
        public PermisionEntity Permision { get; set; }
#nullable enable
        public int Id { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public int PermisionId { get; set; }
    }
}
