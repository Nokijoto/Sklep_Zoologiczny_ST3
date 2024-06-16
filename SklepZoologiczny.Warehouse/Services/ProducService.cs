using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.Storage;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Interfaces;
using SklepZoologiczny.Warehouse.CrossCutting.Dtos;
using SklepZoologiczny.Warehouse.Extension;

namespace SklepZoologiczny.Warehouse.Services
{
    public class ProductService : IProductService
    {
        private readonly WarehouseDbContext _context;

        public ProductService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            return await _context.Products.Select(x=>x.ToDto()).ToListAsync();
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }
            return product.ToDto();
        }
    

        public async Task CreateProductAsync(CreateProductDto product)
        {
            
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == product.CategorieId);
            
            if (!categoryExists)
            {
            throw new ArgumentException($"Invalid CategoryId specified. Id given: {product.CategorieId}");
            }

            var productEntity = product.ToEntity();
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateProductAsync(Guid id, CreateProductDto updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}