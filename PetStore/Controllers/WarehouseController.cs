using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Interfaces;

namespace PetStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;

        // GET: WarehouseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WarehouseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WarehouseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WarehouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WarehouseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WarehouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WarehouseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WarehouseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //[HttpGet("/products/")]
        //[Route("GetAllProducts")]
        //public Task<ProductDto> GetAllProducts()
        //{
        //    return View();
        //    Ok(_warehouseService.GetAllProducts());
        //}
    }
}
