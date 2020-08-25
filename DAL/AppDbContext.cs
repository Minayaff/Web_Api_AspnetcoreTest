using ApiTest.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dress" },
                new Category { Id = 2, Name = "Shoes" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id=1,Name="T-shirt Woman",Price=100,CategoryId=1},
                new Product { Id=2,Name="T-shirt Man",Price=50,CategoryId=1},
                new Product { Id=3,Name="Skirt",Price=140,CategoryId=2},
                new Product { Id=4,Name="Sport Shoes",Price=130,CategoryId=2},
                new Product { Id=5,Name="Classic Shoes",Price=70,CategoryId=2 }

                );
        }
    }
}
