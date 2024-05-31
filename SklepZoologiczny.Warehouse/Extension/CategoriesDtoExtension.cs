using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Extension
{
    public static class CategoriesDtoExtension
    {
        public static Categorie ToEntity(this CategoriesDto category)
        {
            return new Categorie
            {
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };
        }
    }
}
