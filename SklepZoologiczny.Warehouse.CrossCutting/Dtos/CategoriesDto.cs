using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepZoologiczny.Warehouse.CrossCutting.Dtos
{
    public class CategoriesDto 
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public string? ParentCategory { get; set; }

    }
}
