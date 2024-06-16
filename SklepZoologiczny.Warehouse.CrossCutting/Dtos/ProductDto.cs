using SklepZoologiczny.Warehouse.Storage.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepZoologiczny.Warehouse.CrossCutting.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int Quantity { get; set; }

        public int Price { get; set; }
        public Guid CategorieId { get; set; }
        public Guid SupplierId { get; set; }

    }
}
