using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.CrossCutting.Dtos.Warehouse
{
    public class CategoriesDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public string? ParentCategory { get; set; } // Assuming it's the name of the parent category

        public ICollection<string>? Subcategories { get; set; } = new List<string>(); // Assuming Categories is a collection of strings representing category names

        public ICollection<ProductDto>? Products { get; set; } // Assuming ProductDTO is used as the DTO for the Product class
    }
}
