using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductMicroservice.Models;

[GraphQLDescription("Represents a product attribute")]
[Table("ProductAttribute")]
[Index(nameof(ProductId))]
[Index(nameof(ProductAttributeTypeId))]
[Index(nameof(ProductId), nameof(ProductAttributeTypeId))]
[Index(nameof(ProductId), nameof(ProductAttributeTypeId), nameof(Value), IsUnique = true)]
public record ProductAttribute : AbstractEditableRecord
{
    [Column("ProductAttributeId")]
    [Key]
    [GraphQLType(typeof(IdType)), GraphQLNonNullType]
    [GraphQLDescription("A unique identifier, expressed as a UUIDv4 string")]
    public Guid Id { get; set; }

    [Required]
    [GraphQLType(typeof(IdType)), GraphQLNonNullType]
    [GraphQLDescription("The associated product's ID, expressed as a UUIDv4 string")]
    public Guid ProductId { get; set; }

    [Required]
    [GraphQLType(typeof(IdType)), GraphQLNonNullType]
    [GraphQLDescription("The associated product's ID, expressed as a UUIDv4 string")]
    public Guid ProductAttributeTypeId { get; set; }

    public virtual ProductAttributeType ProductAttributeType { get; set; } = default!;

    [Column("AttributeValue", TypeName = "varchar")]
    [MaxLength(64), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The product attribute value")]
    public string Value { get; set; } = default!;
}
