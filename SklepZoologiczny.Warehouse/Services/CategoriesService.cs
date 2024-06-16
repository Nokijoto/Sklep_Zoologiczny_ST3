using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Storage;
using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.Extension;
using SklepZoologiczny.Warehouse.Interfaces;

namespace SklepZoologiczny.Warehouse.Services
{
    public class CategoriesService :  ICategoriesService
    {
        private readonly WarehouseDbContext _context;

        public CategoriesService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriesDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(c => c.ToDto()).ToList();

        }

        public async Task<CategoriesDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }
            return category.ToDto();
        }

        public async Task CreateCategoryAsync(CreateCategoriesDto category)
        {


            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            var newCategory = category.ToEntity();
            try
            {
                _context.Categories.Add(newCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An unexpected error occurred.", ex);
            }
        }

        public async Task UpdateCategoryAsync(Guid id, CreateCategoriesDto updatedCategory)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            category.Name = updatedCategory.Name;
            category.ParentCategoryId = updatedCategory.ParentCategoryId;

            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
