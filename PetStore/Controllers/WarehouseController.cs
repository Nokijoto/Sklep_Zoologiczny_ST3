using Microsoft.AspNetCore.Mvc;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStore.Controllers
{
    [ApiController]
    [Route("api")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        // Action to return a view
        //[HttpGet]
        //[Route("/Warehouse/Index")]
        //public async Task<IActionResult> Index()
        //{
        //    var categories = await _warehouseService.GetAllCategoriesAsync();
        //    var products = await _warehouseService.GetAllProductsAsync();
        //    var suppliers = await _warehouseService.GetSuppliersAsync();

        //    // Create a view model or pass the data directly to the view
        //    var viewModel = new WarehouseViewModel
        //    {
        //        Categories = categories,
        //        Products = products,
        //        Suppliers = suppliers
        //    };

        //    return View(viewModel);
        //}

        // Get all categories
        [HttpGet("categories")]
        public async Task<ActionResult<List<CategoriesDto>>> GetCategories()
        {
            var categories = await _warehouseService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // Get category by ID
        [HttpGet("categories/{id:guid}")]
        public async Task<ActionResult<CategoriesDto>> GetCategory(Guid id)
        {
            var category = await _warehouseService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // Get all products
        [HttpGet("products")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _warehouseService.GetAllProductsAsync();
            return Ok(products);
        }

        // Get product by ID
        [HttpGet("products/{id:guid}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var product = await _warehouseService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Get products by category ID
        [HttpGet("products/bycategory/{categoryId:guid}")]
        public async Task<ActionResult<List<ProductDto>>> GetProductsByCategory(Guid categoryId)
        {
            var products = await _warehouseService.GetProductsByCategoryAsync(categoryId);
            return Ok(products);
        }

        // Get all suppliers
        [HttpGet("suppliers")]
        public async Task<ActionResult<List<SupplierDto>>> GetSuppliers()
        {
            var suppliers = await _warehouseService.GetSuppliersAsync();
            return Ok(suppliers);
        }

        // Get supplier by ID
        [HttpGet("suppliers/{id:guid}")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(Guid id)
        {
            var supplier = await _warehouseService.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }
    }
}
