using System;

namespace SuperMegaHyperPuperShop.Models
{
    public class PersonModel
    {
#nullable disable
        public string Name { get; set; }
        public string Id { get; set; }
        public PermissionModel Permission { get; set; }
#nullable enable
        public int PermissionId { get; set; }
    }
}
