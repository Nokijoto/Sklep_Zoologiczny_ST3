using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Storage.Entities;

public class InventoryTransaction: BaseEntity
{
    [Required]
    public Guid ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required]
    public Guid EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public DateTime TransactionDate { get; set; }
}