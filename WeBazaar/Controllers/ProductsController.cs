using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using WeBazaar.Data;
using WeBazaar.Data.Services;

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
    }
}
