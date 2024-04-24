using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;
using WeBazaar.Data;
using WeBazaar.Data.Services;
using WeBazaar.Models;

namespace WeBazaar.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
            //var = _context:
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }


        //Get: Products and create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Product product)
        {
            if (product.FullName != null && product.ProfilePictureURL != null && product.Bio != null)
            {
                await _service.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Get: Products/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);

            if (productDetails == null) return View("NotFound");
            return View(productDetails);    
        }

        //Get: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Product product)
        {
            if (product.FullName != null && product.ProfilePictureURL != null && product.Bio != null)
            {
                await _service.UpdateAsync(id, product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        //Get: Products/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");
            return View(productDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
