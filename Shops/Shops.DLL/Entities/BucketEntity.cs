using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMegaHyperPuperShop.DAL.Entities
{
    public class BucketEntity
    {
#nullable disable
        public ItemEntity Item { get; set; }
        public PersonEntity Person { get; set; }
#nullable enable
        public int Id { get; set; }
        public int ItemCount { get; set; }
        public int ItemId { get; set; }
        public string PersonId { get; set; }
    }
}
