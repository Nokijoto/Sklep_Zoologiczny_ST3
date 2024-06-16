using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.CrossCutting.Dtos.Warehouse
{
    public class CategoriesDto : ExternalSource
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public string? ParentCategory { get; set; } 

        public ICollection<string>? Subcategories { get; set; } = new List<string>(); 

        public ICollection<ProductDto>? Products { get; set; }
    }
}
