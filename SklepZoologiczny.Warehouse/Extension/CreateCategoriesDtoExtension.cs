using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Extension
{
    public static class CreateCategoriesDtoExtension
    {
        public static Categorie ToEntity(this CreateCategoriesDto category)
        {
            return new Categorie
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }
        public static CategoriesDto ToDto(this CreateCategoriesDto category)
        {
            return new CategoriesDto
            {
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }

    }
}
