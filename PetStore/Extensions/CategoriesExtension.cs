using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Extensions
{
    public static class CategorieExtension
    {
        public static CategoriesDto ToDto(this Categorie category)
        {
            return new CategoriesDto
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }
    }
}
