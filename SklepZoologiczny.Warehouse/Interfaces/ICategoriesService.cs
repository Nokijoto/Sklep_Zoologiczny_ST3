using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage.Entities;

namespace SklepZoologiczny.Warehouse.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoriesDto>> GetAllCategoriesAsync();
        Task<CategoriesDto> GetCategoryByIdAsync(Guid id);

        Task CreateCategoryAsync(CreateCategoriesDto category);
        Task UpdateCategoryAsync(Guid id, CreateCategoriesDto updatedCategory);
        Task DeleteCategoryAsync(Guid id);

    }
}