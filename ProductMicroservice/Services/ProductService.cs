using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Contexts;
using ProductMicroservice.Inputs;
using ProductMicroservice.Models;

namespace ProductMicroservice.Services;

public class ProductService : IAsyncDisposable
{
    public static readonly Guid DEFAULT_USER_ID = Guid.Parse("c99da33d-e22e-4439-8f00-2461c94c9a8b");
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

    public ProductAttributeType? CreateProductAttributeType(CreateProductAttributeTypeInput input, Guid userId)
    {
        var datetime = DateTime.Now;

        var record = new ProductAttributeType
        {
            Id = Guid.NewGuid(),
            Code = input.Code,
            Name = input.Name,
            AreMultipleEntriesAllowed = input.AreMultipleEntriesAllowed,
            IsActive = true,
            CreatedBy = userId,
            CreatedDateTime = datetime,
            ModifiedBy = userId,
            ModifiedDateTime = datetime
        };

        _context.ProductAttributeTypes.Add(record);
        _context.SaveChanges();

        return GetProductAttributeType(record.Id);
    }


    public ProductAttributeType? UpdateProductAttributeType(UpdateProductAttributeTypeInput input, Guid userId)
    {
        var record = GetProductAttributeType(input.Id);

        if (record is not null)
        {
            record.Code = input.Code;
            record.Name = input.Name;
            record.AreMultipleEntriesAllowed = input.AreMultipleEntriesAllowed;
            record.IsActive = input.IsActive;
            record.ModifiedBy = userId;
            record.ModifiedDateTime = DateTime.Now;

            _context.ProductAttributeTypes.Update(record);
            _context.SaveChanges();
        }

        return record;
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
