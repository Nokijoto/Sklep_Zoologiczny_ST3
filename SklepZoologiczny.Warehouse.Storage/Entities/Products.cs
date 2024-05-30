using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SklepZoologiczny.Common.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Storage.Entities
{
    public class Products : BaseEntity
    {

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        //[Required]
        //[MaxLength(255)]
        //public Categories? Category { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        //[ForeignKey("SupplierId")]
        //public Supplier Supplier { get; set; }

        [Required]
        public int ReorderLevel { get; set; } = 0;

    }
}
