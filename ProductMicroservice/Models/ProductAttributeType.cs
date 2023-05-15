using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductMicroservice.Models;

[GraphQLDescription("Represents a product attribute type")]
[Table("ProductAttributeType")]
[Index(nameof(Code), IsUnique = true)]
[Index(nameof(Name), IsUnique = true)]
public record ProductAttributeType : AbstractEditableRecord
{
    [Column("ProductAttributeTypeId")]
    [Key]
    [GraphQLType(typeof(IdType)), GraphQLNonNullType]
    [GraphQLDescription("A unique identifier, expressed as a UUIDv4 string")]
    public Guid Id { get; set; }

    [Column("ProductAttributeTypeCode", TypeName = "varchar")]
    [MaxLength(64), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("A unique code used to identify this attribute type")]
    public string Code { get; set; } = default!;

    [Column("ProductAttributeTypeName", TypeName = "varchar")]
    [MaxLength(64), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The us-en name of this attribute type")]
    public string Name { get; set; } = default!;

    [Required]
    [GraphQLNonNullType]
    [GraphQLDescription("Denotes whether a product can have multiple product attribute values for this type")]
    public bool AreMultipleEntriesAllowed { get; set; }

    [Required]
    [GraphQLNonNullType]
    [GraphQLDescription("Denotes whether this record is active")]
    public bool IsActive { get; set; }
}
