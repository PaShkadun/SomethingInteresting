using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Entities;

namespace SuperMegaHyperPuperShop.DAL.Datas
{
    public class DataContext : DbContext
    {
        public DbSet<BookmarkEntity> Bookmarks { get; set; }
        public DbSet<BucketEntity> Buckets { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<OrderHistoryEntity> OrderHistories { get; set; }
        public DbSet<OrderInfoEntity> OrderInfos { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<PermisionEntity> Permisions { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
