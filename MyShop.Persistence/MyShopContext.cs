using Microsoft.EntityFrameworkCore;

using MyShop.Domain.Models;

namespace MyShop.Persistence;

public class MyShopContext : DbContext
{
    public MyShopContext(DbContextOptions<MyShopContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Product>()
            .Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(300);

        modelBuilder.Entity<Product>()
            .Property(c => c.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ProductImage>()
            .Property(c => c.Path)
            .IsRequired()
            .HasMaxLength(500);
    }
}