using SklepZoologiczny.Common.Storage.Entities;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Storage.Entities.Warehouse
{
    public class Employee : BaseEntity
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string ContactInformation { get; set; }

        public ICollection<InventoryTransaction> InventoryTransactions { get; set; }


        public Guid ExternalId { get; set; }
        public string ExternalSourceName { get; set; }
    }
}