using SklepZoologiczny.Warehouse.Storage.Entities;
using SklepZoologiczny.Warehouse.Storage;
using Microsoft.EntityFrameworkCore;
using SklepZoologiczny.Warehouse.Interfaces;

namespace SklepZoologiczny.Warehouse.Services
{
    public class ProductService : IProductService
    {
        private readonly WarehouseDbContext _context;

        public ProductService(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }
            return product;
        }
    

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Guid id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found.");
            }

            product.Name = updatedProduct.Name;
            product.Category = updatedProduct.Category;
            product.Supplier = updatedProduct.Supplier;
            product.Price = updatedProduct.Price;
            product.Quantity = updatedProduct.Quantity;

            await _context.SaveChangesAsync();
            return product;
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