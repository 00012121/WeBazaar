using Microsoft.EntityFrameworkCore;
using WeBazaar.Models;

namespace WeBazaar.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Item>().HasKey(am => new
            {
                am.ProductId,
                am.ItemId
            });

            modelBuilder.Entity<Product_Item>().HasOne(m => m.Item).WithMany(am => am.Products_Items)
                .HasForeignKey(am => am.ItemId);

            modelBuilder.Entity<Product_Item>().HasOne(m => m.Product).WithMany(am => am.Products_Items)
                .HasForeignKey(am => am.ProductId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product_Item> Products_Items { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
