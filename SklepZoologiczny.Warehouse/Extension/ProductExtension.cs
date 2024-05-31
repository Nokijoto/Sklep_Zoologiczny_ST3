using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Extension
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
