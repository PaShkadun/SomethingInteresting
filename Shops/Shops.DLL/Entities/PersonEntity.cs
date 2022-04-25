using System;

namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class PersonEntity
    {
#nullable disable
        public string Name { get; set; }
        public string Id { get; set; }
        public PermissionEntity Permission { get; set; }
#nullable enable
        public int PermissionId { get; set; }
    }
}
