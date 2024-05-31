using System.ComponentModel.DataAnnotations;
using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Storage.Entities;

public class Supplier: BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(255)]
    public string Email { get; set; }

    [MaxLength(50)]
    public string Phone { get; set; }

    [MaxLength(255)]
    public string Street { get; set; }

    [MaxLength(255)]
    public string City { get; set; }

    [MaxLength(50)]
    public string State { get; set; }

    [MaxLength(20)]
    public string ZipCode { get; set; }

    [MaxLength(255)]
    public string Country { get; set; }

    public ICollection<Product> Products { get; set; }
}