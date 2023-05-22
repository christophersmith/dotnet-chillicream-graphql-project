using ProductMicroservice.Inputs;
using ProductMicroservice.Models;
using ProductMicroservice.Services;

namespace ProductMicroservice.Types;

[GraphQLName("Mutation")]
public class MutationType
{
    [GraphQLDescription("Creates a product attribute type record and returns the record if the product attribute type is created.")]
    [UseMutationConvention]
    public ProductAttributeType? CreateProductAttributeType(
            [Service]
            ProductService service,
            [GraphQLNonNullType]
            [GraphQLDescription("The product attribute type's input payload")]
            CreateProductAttributeTypeInput input
        )
    {
        return service.CreateProductAttributeType(input, ProductService.DEFAULT_USER_ID);
    }

    [GraphQLDescription("Updates a product attribute type record and returns the record if the product attribute type is found and updated.")]
    [UseMutationConvention]
    public ProductAttributeType? UpdateProductAttributeType(
            [Service]
            ProductService service,
            [GraphQLNonNullType]
            [GraphQLDescription("The product attribute type's input payload")]
            UpdateProductAttributeTypeInput input
        )
    {
        return service.UpdateProductAttributeType(input, ProductService.DEFAULT_USER_ID);
    }

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
