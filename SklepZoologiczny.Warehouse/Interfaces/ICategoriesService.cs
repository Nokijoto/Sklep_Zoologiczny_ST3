using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoriesDto>> GetAllCategoriesAsync();
        Task<Categorie> GetCategoryByIdAsync(Guid id);
        Task<CategoriesDto> CreateCategoryAsync(CategoriesDto category);
        Task<Categorie> UpdateCategoryAsync(Guid id, CategoriesDto updatedCategory);
        Task DeleteCategoryAsync(Guid id);

    }
}