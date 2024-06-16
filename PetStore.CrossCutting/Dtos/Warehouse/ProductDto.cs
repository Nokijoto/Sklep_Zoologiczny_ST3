using System.ComponentModel.DataAnnotations;

namespace PetStore.CrossCutting.Dtos.Warehouse
{
    public class ProductDto : ExternalSource
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