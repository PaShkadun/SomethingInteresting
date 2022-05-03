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
                    new CategoryEntity { Name = "TV", Id = 1, ImgSrc = "TVs/logoTV.png" },
                    new CategoryEntity { Name = "Laptop", Id = 2, ImgSrc = "Laptops/logoLaptop.png" },
                    new CategoryEntity { Name = "PC", Id = 3, ImgSrc = "PCs/logoPC.png" },
                    new CategoryEntity { Name = "Coffee machines", Id = 4, ImgSrc = "Coffees/logoCoffee.png" },
                    new CategoryEntity { Name = "Wash machines", Id = 5, ImgSrc = "Washes/logoWash.png" },
                    new CategoryEntity { Name = "Hard disks", Id = 6, ImgSrc = "HDisks/logoDisk.png" }
                });

            modelBuilder.Entity<PermissionEntity>()
                .HasData(new[]
                {
                    new PermissionEntity
                    {
                        Id = 1,
                        Role = "user",
                    },
                    new PermissionEntity
                    {
                        Id = 2,
                        Role = "admin"
                    }
                });

            modelBuilder.Entity<ItemEntity>()
                .HasData(new[]
                {
                    new ItemEntity 
                    { 
                        Name = "Супер телевизор", 
                        Id = 1, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/firstTV.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Мега телевизор", 
                        Id = 2, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/secondTV.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Гипер телевизор", 
                        Id = 3, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/thirdTV.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "Пупер телевизор", 
                        Id = 4, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/puperTV.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Телевизор-милашка", 
                        Id = 5, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/niceTV.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Злой телевизор", 
                        Id = 6, 
                        CategoryId = 1, 
                        ImgSrc = "TVs/angryTV.png", 
                        Count = 3, 
                        Price = 666 
                    },
                    new ItemEntity 
                    { 
                        Name = "Супер ноутбук", 
                        Id = 7, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/firstLaptop.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Мега ноутбук", 
                        Id = 8, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/secondLaptop.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Гипер ноутбук", 
                        Id = 9, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/thirdLaptop.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "Пупер ноутбук", 
                        Id = 10, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/puperLaptop.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Ноутбук-милашка", 
                        Id = 11, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/niceLaptop.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Злой ноутбук", 
                        Id = 12, 
                        CategoryId = 2, 
                        ImgSrc = "Laptops/angryLaptop.png", 
                        Count = 3, 
                        Price = 666 
                    },
                    new ItemEntity 
                    { 
                        Name = "Супер компьютер", 
                        Id = 13, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/firstPC.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Мега компьютер", 
                        Id = 14, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/secondPC.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Гипер компьютер", 
                        Id = 15, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/thirdPC.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "Пупер компьютер", 
                        Id = 16, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/puperPC.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Телевизор-милашка", 
                        Id = 17, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/nicePC.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Злой компьютер", 
                        Id = 18, 
                        CategoryId = 3, 
                        ImgSrc = "PCs/angryPC.png", 
                        Count = 3, 
                        Price = 666 
                    },
                    new ItemEntity 
                    { 
                        Name = "Супер кофейкник", 
                        Id = 19, 
                        CategoryId = 4, 
                        ImgSrc = "Coffees/firstCoffee.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Мега кофейник", 
                        Id = 20, 
                        CategoryId = 4, 
                        ImgSrc = "Coffees/secondCoffee.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Гипер кофейник", 
                        Id = 21, 
                        CategoryId = 4, 
                        ImgSrc = "Coffees/thirdCoffee.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "Пупер кофейник", 
                        Id = 22, 
                        CategoryId = 4, 
                        ImgSrc = "Coffees/puperCoffee.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Кофейник-милашка", 
                        Id = 23, 
                        CategoryId = 4, 
                        ImgSrc = "Coffees/niceCoffee.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Злой кофейник", 
                        Id = 24, 
                        CategoryId = 4, 
                        ImgSrc = "Coffees/angryCoffee.png", 
                        Count = 3, 
                        Price = 666 
                    },
                    new ItemEntity 
                    { 
                        Name = "Супер стиралка", 
                        Id = 25, 
                        CategoryId = 5, 
                        ImgSrc = "Washes/firstWash.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Мега стиралка", 
                        Id = 26, 
                        CategoryId = 5, 
                        ImgSrc = "Washes/secondWash.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Гипер стиралка", 
                        Id = 27, 
                        CategoryId = 5, 
                        ImgSrc = "Washes/thirdWash.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "Пупер стиралка", 
                        Id = 28, 
                        CategoryId = 5, 
                        ImgSrc = "Washes/puperWash.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Стиралка-милашка", 
                        Id = 29, 
                        CategoryId = 5, 
                        ImgSrc = "Washes/niceWash.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Злая стиралка", 
                        Id = 30, 
                        CategoryId = 5, 
                        ImgSrc = "Washes/angryWash.png", 
                        Count = 3, 
                        Price = 666 
                    },
                    new ItemEntity 
                    { 
                        Name = "Супер жёсткий диск", 
                        Id = 31, 
                        CategoryId = 6, 
                        ImgSrc = "HDisks/firstDisk.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Мега жёсткий диск", 
                        Id = 32, 
                        CategoryId = 6, 
                        ImgSrc = "HDisks/secondDIsk.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Гипер жёсткий диск", 
                        Id = 33, 
                        CategoryId = 6, 
                        ImgSrc = "HDisks/thirdDisk.png", 
                        Count = 3, 
                        Price = 300 
                    },
                    new ItemEntity 
                    { 
                        Name = "Пупер жёсткий диск", 
                        Id = 34, 
                        CategoryId = 6, 
                        ImgSrc = "HDisks/puperDisk.png", 
                        Count = 1, 
                        Price = 100 
                    },
                    new ItemEntity 
                    { 
                        Name = "Жёсткий диск-милашка", 
                        Id = 35, 
                        CategoryId = 6, 
                        ImgSrc = "HDisks/niceDisk.png", 
                        Count = 2, 
                        Price = 200 
                    },
                    new ItemEntity 
                    { 
                        Name = "Злой жёсткий диск", 
                        Id = 36, 
                        CategoryId = 6, 
                        ImgSrc = "HDisks/angryDisk.png", 
                        Count = 3, 
                        Price = 666 
                    }
                });
        }
    }
}
