using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.CrossCutting.Dtos.Warehouse
{
    public class SupplierDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }
        public Guid ExternalId { get; set; }
        public string ExternalSourceName { get; set; }

        public ICollection<string> Products { get; set; } 
    }
}
