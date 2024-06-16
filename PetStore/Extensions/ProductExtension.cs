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
                Quantity = product.Quantity,
                Price = product.Price,
                CategorieId = product.CategorieId,
                SupplierId = product.SupplierId,
                ExternalId = product.ExternalId,
                ExternalSourceName = product.ExternalSourceName,
                
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
                Quantity = product.Quantity,
                SupplierId = product.SupplierId,
                CategorieId = product.CategorieId,
                ExternalId = product.ExternalId,
                ExternalSourceName = product.ExternalSourceName,
            };
        }
    }
}
