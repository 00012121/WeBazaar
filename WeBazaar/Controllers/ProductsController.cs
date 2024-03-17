using Microsoft.AspNetCore.Mvc;
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
            var data = await _service.GetAll();
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
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                _service.Add(product);
                return RedirectToAction(nameof(Index));

            }
        }
    }
}
