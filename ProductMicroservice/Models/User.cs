namespace ProductMicroservice.Models;

[GraphQLDescription("Represents a user")]
public record User
{
    [GraphQLType(typeof(IdType)), GraphQLNonNullType]
    [GraphQLDescription("A unique identifier, expressed as a UUIDv4 string")]
    public Guid Id { get; set; }
}
