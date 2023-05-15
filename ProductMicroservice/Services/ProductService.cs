using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProductMicroservice.Contexts;
using ProductMicroservice.Models;

namespace ProductMicroservice.Services;

public class ProductService : IAsyncDisposable
{
    private readonly ProductDbContext _context;

    public ProductService(IDbContextFactory<ProductDbContext> dbContextFactory)
    {
        _context = dbContextFactory.CreateDbContext();
    }

    public Product? GetProduct(Guid id)
    {
        return _context.Products
            .Where(p => p.Id == id)
            .Include(a => a.ProductAttributes)
            .ThenInclude(t => t.ProductAttributeType)
            .FirstOrDefault();
    }

    public IQueryable<Product> GetProductsAsQueryable()
    {
        return _context.Products
            .Include(a => a.ProductAttributes)
            .ThenInclude(t => t.ProductAttributeType)
            .AsQueryable();
    }

    public ProductAttributeType? GetProductAttributeType(Guid id)
    {
        return _context.ProductAttributeTypes.Find(id);
    }

    public IQueryable<ProductAttributeType> GetProductAttributeTypesAsQueryable()
    {
        return _context.ProductAttributeTypes.AsQueryable();
    }

    public Product? DeleteProduct(Guid id)
    {
        var record = _context.Products.Where(x => x.Id.Equals(id)).FirstOrDefault();
        if (record is not null)
        {
            _context.Products.Remove(record);
            _context.SaveChanges();
        }
        return record;
    }

    public ProductAttribute? DeleteProductAttribute(Guid id)
    {
        var record = _context.ProductAttributes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        if (record is not null)
        {
            _context.ProductAttributes.Remove(record);
            _context.SaveChanges();
        }
        return record;
    }

    public ProductAttributeType? DeleteProductAttributeType(Guid id)
    {
        var record = _context.ProductAttributeTypes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        if (record is not null)
        {
            _context.ProductAttributeTypes.Remove(record);
            _context.SaveChanges();
        }
        return record;
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }
}
