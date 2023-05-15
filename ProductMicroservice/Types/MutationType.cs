using ProductMicroservice.Models;
using ProductMicroservice.Services;

namespace ProductMicroservice.Types;

[GraphQLName("Mutation")]
public class MutationType
{
    [GraphQLDescription("Deletes a product record, for the specified ID, and returns the record if the product is found.")]
    [UseMutationConvention]
    public Product? DeleteProduct(
            [Service]
            ProductService service,
            [GraphQLType(typeof(IdType)), GraphQLNonNullType]
            [GraphQLDescription("The product's identifier, represented as an UUIDv4")]
            Guid id
        )
    {
        return service.DeleteProduct(id);
    }

    [GraphQLDescription("Deletes a product attribute record, for the specified ID, and returns the record if the product attribute is found.")]
    [UseMutationConvention]
    public ProductAttribute? DeleteProductAttribute(
            [Service]
            ProductService service,
            [GraphQLType(typeof(IdType)), GraphQLNonNullType]
            [GraphQLDescription("The product attribute's identifier, represented as an UUIDv4")]
            Guid id
        )
    {
        return service.DeleteProductAttribute(id);
    }

    [GraphQLDescription("Deletes a product attribute type record, for the specified ID, and returns the record if the product attribute type is found.")]
    [UseMutationConvention]
    public ProductAttributeType? DeleteProductAttributeType(
            [Service]
            ProductService service,
            [GraphQLType(typeof(IdType)), GraphQLNonNullType]
            [GraphQLDescription("The product attribute type's identifier, represented as an UUIDv4")]
            Guid id
        )
    {
        return service.DeleteProductAttributeType(id);
    }
}
