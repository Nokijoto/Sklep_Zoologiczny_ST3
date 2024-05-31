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

        public async Task<Categorie> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }
            return category;
        }

        public async Task<CategoriesDto> CreateCategoryAsync(CategoriesDto category)
        {
            var newCategory = category.ToEntity();
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.ToDto();
        }

        public async Task<Categorie> UpdateCategoryAsync(Guid id, CategoriesDto updatedCategory)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new Exception("Category not found.");
            }

            category.Name = updatedCategory.Name;
            category.ParentCategoryId = updatedCategory.ParentCategoryId;

            await _context.SaveChangesAsync();
            return category;
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
