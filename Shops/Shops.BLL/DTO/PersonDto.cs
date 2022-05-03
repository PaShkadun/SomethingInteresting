using System;

namespace SuperMegaHyperPuperShop.BLL.DTO
{
    public class PersonDto
    {
#nullable disable
        public string Name { get; set; }
        public string Id { get; set; }
        public PermissionDto Permission { get; set; }
#nullable enable
        public int PermissionId { get; set; }
    }
}
