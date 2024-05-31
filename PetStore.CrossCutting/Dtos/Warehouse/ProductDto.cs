using System.ComponentModel.DataAnnotations;

namespace PetStore.CrossCutting.Dtos.Warehouse
{
    public class ProductDto 
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }

        public string Quantity { get; set; }

        public int Price { get; set; }


    }
}