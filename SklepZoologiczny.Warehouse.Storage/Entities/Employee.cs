using System.ComponentModel.DataAnnotations;
using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Storage.Entities;

public class Employee: BaseEntity
{
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(1000)]
    public string ContactInformation { get; set; }

    public ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
}