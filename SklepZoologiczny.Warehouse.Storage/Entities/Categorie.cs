using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Storage.Entities;

public class Categorie: BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? ParentCategoryId { get; set; }

    [ForeignKey("ParentCategoryId")]
    public Categorie? ParentCategory { get; set; }

    public ICollection<Categorie> Subcategories { get; set; } = new List<Categorie>();

    [ForeignKey("ParentId")]
    public ICollection<Product>? Products { get; set; }
}