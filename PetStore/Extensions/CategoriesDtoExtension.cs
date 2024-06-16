using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Extensions
{
    public static class CategoriesDtoExtension
    {
        public static Categorie ToEntity(this CategoriesDto category)
        {
            return new Categorie
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId,
                Description = category.Description,
            };
        }
    }
}
