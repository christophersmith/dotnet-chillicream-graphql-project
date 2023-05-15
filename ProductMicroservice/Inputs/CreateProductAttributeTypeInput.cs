namespace ProductMicroservice.Inputs;

[GraphQLDescription("Represents a product attribute type to be created")]
public class CreateProductAttributeTypeInput
{
    [GraphQLNonNullType]
    [GraphQLDescription("A unique code used to identify this attribute type")]
    public string Code { get; set; } = default!;

    [GraphQLNonNullType]
    [GraphQLDescription("The us-en name of this attribute type")]
    public string Name { get; set; } = default!;

    [GraphQLNonNullType]
    [GraphQLDescription("Denotes whether a product can have multiple product attribute values for this type")]
    public bool AreMultipleEntriesAllowed { get; set; }

    [GraphQLNonNullType]
    [GraphQLDescription("Denotes whether this record is active")]
    public bool IsActive { get; set; }
}
