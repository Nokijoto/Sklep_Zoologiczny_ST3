using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensibility;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Extensions;
using PetStore.Interfaces;
using PetStore.Resolver;
using PetStore.Storage;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly WarehouseIntegrationDataResolver _dataResolver;
        private readonly SuppliersDataResolver _suppliersDataResolver;
        private readonly CategoriesDataResolver _categoriesDataResolver;
        private PetStoreDbContext _dbContext;

        public WarehouseService(PetStoreDbContext dbContext,WarehouseIntegrationDataResolver dataResolver, SuppliersDataResolver suppliersDataResolver,CategoriesDataResolver categoriesDataResolver)
        {
            _dataResolver = dataResolver;
            _dbContext = dbContext;
            _suppliersDataResolver = suppliersDataResolver;
            _categoriesDataResolver = categoriesDataResolver;
        }


        public async Task<List<CategoriesDto>> GetAllCategoriesAsync()
        {
            try
            {
                if (_dbContext.Categories != null && await _dbContext.Categories.AnyAsync())
                {
                    return await _dbContext.Categories.Select(s => s.ToDto()).ToListAsync();
                }
                else
                {
                    List<CategoriesDto> dataFromResolver = await _categoriesDataResolver.GetAllCategoriesAsync();

                    var categories = dataFromResolver.Select(s => s.ToEntity()).ToList();

                    _dbContext.Categories.AddRange(categories);
                    await _dbContext.SaveChangesAsync();

                    return await _dbContext.Categories.Select(s => s.ToDto()).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            try
            {
                if (_dbContext.Products != null && await _dbContext.Products.AnyAsync())
                {
                    return await _dbContext.Products.Select(s => s.ToDto()).ToListAsync();
                }
                else
                {
                    List<ProductDto> dataFromResolver = await _dataResolver.GetAllProductAsync();

                    var products = dataFromResolver.Select(s => s.ToEntity()).ToList();

                    _dbContext.Products.AddRange(products);
                    await _dbContext.SaveChangesAsync();

                    return await _dbContext.Products.Select(s => s.ToDto()).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task<CategoriesDto> GetCategoryByIdAsync(Guid id)
        {
            try
            {
                var categorie = await _dbContext.Categories.FindAsync(id);

                if (categorie != null)
                {
                    return categorie.ToDto();
                }
                else
                {
                    var categorieFromResolver = await _categoriesDataResolver.GetCategorieByIdAsync(id);

                    if (categorieFromResolver != null)
                    {
                        var newcategory = categorieFromResolver.ToEntity();
                        _dbContext.Categories.Add(newcategory);
                        await _dbContext.SaveChangesAsync();
                        return newcategory.ToDto();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            try
            {
                var product = await _dbContext.Products.FindAsync(id);

                if (product != null)
                {
                    return product.ToDto();
                }
                else
                {
                    var productDtoFromResolver = await _dataResolver.GetProductByIdAsync(id);

                    if (productDtoFromResolver != null)
                    {
                        var newProduct = productDtoFromResolver.ToEntity();
                        _dbContext.Products.Add(newProduct);
                        await _dbContext.SaveChangesAsync();
                        return newProduct.ToDto();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task<List<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            try
            {
                var products = await _dbContext.Products.Where(p => p.Category == categoryId.ToString()).ToListAsync();
                if(products!=null)
                {
                    return products.Select(p => p.ToDto()).ToList();
                }
                else
                {
                    List<ProductDto> dataFromResolver = await _dataResolver.GetProductsByCategoryAsync(categoryId);
                    var data = dataFromResolver.Select(s => s.ToEntity()).ToList();
                    _dbContext.Products.AddRange(data);
                    await _dbContext.SaveChangesAsync();
                    return await _dbContext.Products.Select(p => p.ToDto()).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<SupplierDto> GetSupplierByIdAsync(Guid id)
        {
            try
            {
                var supplier = await _dbContext.Suppliers.FindAsync(id);

                if (supplier != null)
                {
                    return supplier.ToDto();
                }
                else
                {
                    var supplierDtoFromResolver = await _suppliersDataResolver.GetSupplierByIdAsync(id);

                    if (supplierDtoFromResolver != null)
                    {
                        var newSupplier = supplierDtoFromResolver.ToEntity();
                        _dbContext.Suppliers.Add(newSupplier);
                        await _dbContext.SaveChangesAsync();

                        return newSupplier.ToDto();
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<List<SupplierDto>> GetSuppliersAsync()
        {
            try
            {
                if (_dbContext.Suppliers != null && await _dbContext.Suppliers.AnyAsync())
                {
                    return await _dbContext.Suppliers.Select(s => s.ToDto()).ToListAsync();
                }
                else
                {
                    List<SupplierDto> dataFromResolver = await _suppliersDataResolver.GetAllSupplierAsync();

                    var suppliers = dataFromResolver.Select(s => s.ToEntity()).ToList();

                    _dbContext.Suppliers.AddRange(suppliers);
                    await _dbContext.SaveChangesAsync();

                    return await _dbContext.Suppliers.Select(s => s.ToDto()).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
