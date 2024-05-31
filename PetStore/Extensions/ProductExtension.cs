using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Extensions
{
    public static class ProductExtension
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }
    }

    public static class ProductDtoExtension
    {
        public static Product ToEntity(this ProductDto product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Quantity = product.Quantity
            };
        }
    }
}
