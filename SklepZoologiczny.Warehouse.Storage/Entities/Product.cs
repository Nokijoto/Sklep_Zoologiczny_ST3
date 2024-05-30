using SklepZoologiczny.Common.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepZoologiczny.Warehouse.Storage.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }    
        public string Quanitity { get; set; }   
        public decimal Price {get; set; }
        public string Supplier { get; set; }
       
    }
}
