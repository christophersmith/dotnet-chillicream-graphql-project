using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductMicroservice.Models;

[GraphQLDescription("Represents a product")]
[Table("Product")]
[Index(nameof(Sku), IsUnique = true)]
[Index(nameof(Name), IsUnique = true)]
public record Product : AbstractEditableRecord
{
    [Column("ProductId")]
    [Key]
    [GraphQLType(typeof(IdType)), GraphQLNonNullType]
    [GraphQLDescription("A unique identifier, expressed as a UUIDv4 string")]
    public Guid Id { get; set; }

    [Column("SKU", TypeName = "varchar(32)")]
    [Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The Stock Keeping Unit used to identify this product")]
    public string Sku { get; set; } = default!;

    [Column("ProductName", TypeName = "varchar")]
    [MaxLength(64), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The name of this product")]
    public string Name { get; set; } = default!;

    [Column("ProductDescription", TypeName = "varchar")]
    [MaxLength(512), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The product's description")]
    public string Description { get; set; } = default!;

    [Column("UnitMSRP", TypeName = "money")]
    [Precision(6, 2), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The product's Manufacturer Suggested Retail Price for each unit")]
    public decimal UnitMsrp { get; set; }

    [Required]
    [GraphQLNonNullType]
    [GraphQLDescription("Denotes whether the product is active")]
    public bool IsActive { get; set; }

    [Required]
    [GraphQLNonNullType]
    [GraphQLDescription("Denotes whether the product is sellable")]
    public bool IsSellable { get; set; }

    public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = default!;
}
