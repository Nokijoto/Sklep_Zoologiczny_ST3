using SklepZoologiczny.Common.Storage.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Storage.Entities.Warehouse
{
    public class Categorie : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public Categorie? ParentCategory { get; set; }

        public ICollection<Categorie> Subcategories { get; set; } 

        [ForeignKey("ParentId")]
        public ICollection<Product>? Products { get; set; }

        public Guid? ExternalId { get; set; }
        public string? ExternalSourceName { get; set; }

    }
}