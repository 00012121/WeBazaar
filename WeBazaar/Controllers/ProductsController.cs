using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using WeBazaar.Data;

namespace WeBazaar.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Products.ToList();
            return View(data);
        }
    }
}
