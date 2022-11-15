using ProductMicroservice.Models;
using ProductMicroservice.Services;

namespace ProductMicroservice.Types;

[GraphQLName("Query")]
public class QueryType
{
    public Product? GetProduct(
            [Service]
            ProductService service,

            [GraphQLType(typeof(IdType)), GraphQLNonNullType]
            [GraphQLDescription("The product's identifier, represented as a UUIDv4")]
            Guid id
        )
    {
        return service.GetProduct(id);
    }

    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetProducts(
            [Service]
            ProductService service
        )
    {
        return service.GetProductsAsQueryable();
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ProductAttributeType> GetProductAttributeTypes(
            [Service]
            ProductService service
        )
    {
        return service.GetProductAttributeTypesAsQueryable();
    }
}
