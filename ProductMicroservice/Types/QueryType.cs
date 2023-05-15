using ProductMicroservice.Models;
using ProductMicroservice.Services;

namespace ProductMicroservice.Types;

[GraphQLName("Query")]
public class QueryType
{
    [GraphQLDescription("Gets a product record, for the specified ID.")]
    public Product? GetProduct(
            [Service]
            ProductService service,
            [GraphQLType(typeof(IdType)), GraphQLNonNullType]
            [GraphQLDescription("The product's identifier, represented as an UUIDv4")]
            Guid id
        )
    {
        return service.GetProduct(id);
    }

    [GraphQLDescription("Returns a collection of products that match the filter.")]
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

    [GraphQLDescription("Returns a collection of product attribute types that match the filter.")]
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
