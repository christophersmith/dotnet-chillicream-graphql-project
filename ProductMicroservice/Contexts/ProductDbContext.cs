using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Models;

namespace ProductMicroservice.Contexts;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<ProductAttribute> ProductAttributes { get; set; } = default!;
    public DbSet<ProductAttributeType> ProductAttributeTypes { get; set; } = default!;

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var productModelBuilder = modelBuilder.Entity<Product>();

        // make the primary key clustered
        productModelBuilder.HasKey(p => p.Id)
                    .IsClustered(true);

        var productAttributeModelBuilder = modelBuilder.Entity<ProductAttribute>();

        // make the primary key clustered
        productAttributeModelBuilder.HasKey(p => p.Id)
            .IsClustered(true);

        var productAttributeTypeModelBuilder = modelBuilder.Entity<ProductAttributeType>();

        // make the primary key clustered
        productAttributeTypeModelBuilder.HasKey(p => p.Id)
            .IsClustered(true);
    }
}
