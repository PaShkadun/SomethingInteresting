using System;

namespace SuperMegaHyperPuperShop.Models
{
    public class PersonModel
    {
#nullable disable
        public string Name { get; set; }
        public string Id { get; set; }
        public PermissionModel Permision { get; set; }
#nullable enable
        public int PermissionId { get; set; }
    }
}
