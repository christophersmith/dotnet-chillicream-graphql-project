using ProductMicroservice.Contexts;
using ProductMicroservice.Models;
using ProductMicroservice.Services;

namespace DatabaseSeeder.Seeders;

public class ProductDbSeeder
{
    private readonly ProductDbContext _context;

    public ProductDbSeeder(ProductDbContext context)
    {
        _context = context;
    }

    public void Run()
    {
        RemoveAllProductAttributes();
        RemoveAllProductAttributeTypes();
        RemoveAllProducts();

        var modifiedUserId = ProductService.DEFAULT_USER_ID;
        var modifiedDateTime = DateTime.Now;

        var codeProductAttributeTypeDictionary = AddProductAttributeTypes(modifiedUserId, modifiedDateTime);
        var nameProductDictionary = AddProducts(modifiedUserId, modifiedDateTime);
        AddProductAttributes(nameProductDictionary, codeProductAttributeTypeDictionary, modifiedUserId, modifiedDateTime);
    }

    private void AddProductAttributes(
            Dictionary<string, Product> nameProductDictionary,
            Dictionary<string, ProductAttributeType> codeProductAttributeTypeDictionary,
            Guid modifiedUserId,
            DateTime modifiedDateTime
        )
    {
        var productNames = nameProductDictionary.Keys.ToList();

        foreach (var productName in productNames)
        {
            var nameElements = productName.Split(" ");
            var color = nameElements[0];
            var size = nameElements[nameElements.Length - 1];
            var product = nameProductDictionary[productName];

            if (product is null)
            {
                continue;
            }

            _context.ProductAttributes.Add(new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                ProductAttributeTypeId = codeProductAttributeTypeDictionary["CATEGORY"].Id,
                Value = "Widgets",
                CreatedBy = modifiedUserId,
                CreatedDateTime = modifiedDateTime,
                ModifiedBy = modifiedUserId,
                ModifiedDateTime = modifiedDateTime
            });
            _context.ProductAttributes.Add(new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                ProductAttributeTypeId = codeProductAttributeTypeDictionary["COLOR"].Id,
                Value = color,
                CreatedBy = modifiedUserId,
                CreatedDateTime = modifiedDateTime,
                ModifiedBy = modifiedUserId,
                ModifiedDateTime = modifiedDateTime
            });
            _context.ProductAttributes.Add(new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                ProductAttributeTypeId = codeProductAttributeTypeDictionary["SIZE"].Id,
                Value = size,
                CreatedBy = modifiedUserId,
                CreatedDateTime = modifiedDateTime,
                ModifiedBy = modifiedUserId,
                ModifiedDateTime = modifiedDateTime
            });

            _context.SaveChanges();
        }
    }

    private void RemoveAllProductAttributes()
    {
        var records = _context.ProductAttributes.ToList();

        foreach (var record in records)
        {
            _context.ProductAttributes.Remove(record);
            _context.SaveChanges();
        }
    }

    private Dictionary<string, Product> AddProducts(
            Guid modifiedUserId,
            DateTime modifiedDateTime
        )
    {
        var nameProductDictionary = new Dictionary<string, Product>();

        _context.Products.Add(CreateProduct(
            name: "Green Widget - Small",
            description: "A small green widget that will serve all your small widget needs.",
            unitMsrp: 1.24M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Green Widget - Medium",
            description: "A medium green widget that will serve all your medium widget needs.",
            unitMsrp: 1.74M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Green Widget - Large",
            description: "A large green widget that will serve all your large widget needs.",
            unitMsrp: 1.99M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Blue Widget - Small",
            description: "A small blue widget that will serve all your small widget needs.",
            unitMsrp: 1.24M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Blue Widget - Medium",
            description: "A medium blue widget that will serve all your medium widget needs.",
            unitMsrp: 1.74M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Blue Widget - Large",
            description: "A large blue widget that will serve all your large widget needs.",
            unitMsrp: 1.99M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Red Widget - Small",
            description: "A small red widget that will serve all your small widget needs.",
            unitMsrp: 1.24M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Red Widget - Medium",
            description: "A medium red widget that will serve all your medium widget needs.",
            unitMsrp: 1.74M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Red Widget - Large",
            description: "A large red widget that will serve all your large widget needs.",
            unitMsrp: 1.99M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Yellow Widget - Small",
            description: "A small yellow widget that will serve all your small widget needs.",
            unitMsrp: 1.24M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Yellow Widget - Medium",
            description: "A medium yellow widget that will serve all your medium widget needs.",
            unitMsrp: 1.74M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Yellow Widget - Large",
            description: "A large yellow widget that will serve all your large widget needs.",
            unitMsrp: 1.99M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Black Widget - Small",
            description: "A small black widget that will serve all your small widget needs.",
            unitMsrp: 1.24M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Black Widget - Medium",
            description: "A small black widget that will serve all your small widget needs.",
            unitMsrp: 1.74M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));
        _context.Products.Add(CreateProduct(
            name: "Black Widget - Large",
            description: "A large black widget that will serve all your large widget needs.",
            unitMsrp: 1.99M,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime,
            nameProductDictionary: nameProductDictionary
        ));

        _context.SaveChanges();

        return nameProductDictionary;
    }

    private Product CreateProduct(
            string name,
            string description,
            decimal unitMsrp,
            Guid modifiedUserId,
            DateTime modifiedDateTime,
            Dictionary<string, Product> nameProductDictionary
        )
    {
        var record = new Product
        {
            Id = Guid.NewGuid(),
            Sku = $"WDGT{(nameProductDictionary.Count + 1).ToString("D5")}",
            Name = name,
            Description = description,
            UnitMsrp = unitMsrp,
            IsSellable = true,
            IsActive = true,
            CreatedBy = modifiedUserId,
            CreatedDateTime = modifiedDateTime,
            ModifiedBy = modifiedUserId,
            ModifiedDateTime = modifiedDateTime
        };

        nameProductDictionary.Add(record.Name, record);

        return record;
    }

    private void RemoveAllProducts()
    {
        var records = _context.Products.ToList();

        foreach (var record in records)
        {
            _context.Products.Remove(record);
            _context.SaveChanges();
        }
    }

    private Dictionary<string, ProductAttributeType> AddProductAttributeTypes(
            Guid modifiedUserId,
            DateTime modifiedDateTime
        )
    {
        var codeProductAttributeTypeDictionary = new Dictionary<string, ProductAttributeType>();

        _context.ProductAttributeTypes.Add(CreateProductAttributeType(
            code: "COLOR",
            name: "Color",
            areMultipleEntriesAllowed: false,
            codeProductAttributeTypeDictionary: codeProductAttributeTypeDictionary,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime
        ));

        _context.ProductAttributeTypes.Add(CreateProductAttributeType(
            code: "CATEGORY",
            name: "Category",
            areMultipleEntriesAllowed: true,
            codeProductAttributeTypeDictionary: codeProductAttributeTypeDictionary,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime
        ));

        _context.ProductAttributeTypes.Add(CreateProductAttributeType(
            code: "SIZE",
            name: "Size",
            areMultipleEntriesAllowed: false,
            codeProductAttributeTypeDictionary: codeProductAttributeTypeDictionary,
            modifiedUserId: modifiedUserId,
            modifiedDateTime: modifiedDateTime
        ));

        _context.SaveChanges();

        return codeProductAttributeTypeDictionary;
    }

    private void RemoveAllProductAttributeTypes()
    {
        var records = _context.ProductAttributeTypes.ToList();

        foreach (var record in records)
        {
            _context.ProductAttributeTypes.Remove(record);
            _context.SaveChanges();
        }
    }

    private ProductAttributeType CreateProductAttributeType(
            string code,
            string name,
            bool areMultipleEntriesAllowed,
            Guid modifiedUserId,
            DateTime modifiedDateTime,
            Dictionary<string, ProductAttributeType> codeProductAttributeTypeDictionary
        )
    {
        var record = new ProductAttributeType
        {
            Id = Guid.NewGuid(),
            Code = code,
            Name = name,
            AreMultipleEntriesAllowed = areMultipleEntriesAllowed,
            IsActive = true,
            CreatedBy = modifiedUserId,
            CreatedDateTime = modifiedDateTime,
            ModifiedBy = modifiedUserId,
            ModifiedDateTime = modifiedDateTime
        };

        codeProductAttributeTypeDictionary.Add(record.Code, record);

        return record;
    }
}
