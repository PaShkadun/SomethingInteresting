using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Models;

namespace SuperMegaHyperPuperShop.DAL.Datas
{
    public class DataContext : DbContext
    {
        public DbSet<PersonEntity> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
