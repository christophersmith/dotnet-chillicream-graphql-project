using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProductMicroservice.Models;

public abstract record AbstractEditableRecord
{
    [Required]
    [GraphQLIgnore]
    public Guid CreatedBy { get; set; }

    [GraphQLName("createdBy")]
    [NotMapped]
    [GraphQLNonNullType]
    [GraphQLDescription("The user that created this record")]
    public User CreatedByUser
    {
        get => new User { Id = this.CreatedBy };
    }

    [Column(TypeName = "datetime2")]
    [Precision(6), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The datetime of when this record was created")]
    public DateTime CreatedDateTime { get; set; }

    [Required]
    [GraphQLIgnore]
    public Guid ModifiedBy { get; set; }


    [GraphQLName("modifiedBy")]
    [NotMapped]
    [GraphQLNonNullType]
    [GraphQLDescription("The user that last modified this record")]
    public User ModifiedByUser
    {
        get => new User { Id = this.ModifiedBy };
    }

    [Column(TypeName = "datetime2")]
    [Precision(6), Required]
    [GraphQLNonNullType]
    [GraphQLDescription("The datetime of when this record was last modified")]
    public DateTime ModifiedDateTime { get; set; }
}
