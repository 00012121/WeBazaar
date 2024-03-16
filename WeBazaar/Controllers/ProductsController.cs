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

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
    }
}
