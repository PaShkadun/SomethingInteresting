using Microsoft.EntityFrameworkCore;
using SuperMegaHyperPuperShop.DAL.Entities;
using System;

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
        public DbSet<PermissionEntity> Permisions { get; set; }
        public DbSet<PersonEntity> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>()
                .HasData(new[]
                {
                    new CategoryEntity { Name = "TV", Id = 1, ImgSrc = "TVs/logo.png" },
                    new CategoryEntity { Name = "Laptop", Id = 2, ImgSrc = "Laptops/logo.png" },
                    new CategoryEntity { Name = "PC", Id = 3, ImgSrc = "PCs/logo.png" }
                });

            modelBuilder.Entity<ItemEntity>()
                .HasData(new[]
                {
                    new ItemEntity 
                    { 
                        Name = "First TV", 
                        Id = 1, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/firstTV.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Second TV", 
                        Id = 2, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/secondTV.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Third TV", 
                        Id = 3, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/thirdTV.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "First Laptop", 
                        Id = 4, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/firstLaptop.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Second Laptop", 
                        Id = 5, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/secondLaptop.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Third Laptop", 
                        Id = 6, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/thirdLaptop.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "First PC", 
                        Id = 7, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/firstPC.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Second PC", 
                        Id = 8, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/secondPC.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Third PC", 
                        Id = 9, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/thirdPC.png", 
                        Count = 3, 
                        Price = 300 
                    }
                });
        }
    }
}
