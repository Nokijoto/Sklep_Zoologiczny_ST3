using SklepZoologiczny.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Storage.Entities.Warehouse
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Supplier { get; set; }

        public Guid ExternalId { get; set; }
        public string ExternalSourceName { get; set; }
        public ICollection<Categorie> Categories { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}
