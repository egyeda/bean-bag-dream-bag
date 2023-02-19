using BeanBag.Models;
using Microsoft.EntityFrameworkCore;

namespace BeanBag.Data;

public class AppDbContext : DbContext
{
    public AppDbContext( DbContextOptions<AppDbContext> options ) : base( options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity<ProductCategory>()
            .HasKey( pc => new { pc.ProductId, pc.CategoryId } );
        
    }
}