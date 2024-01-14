using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeBazaar.Data;

namespace WeBazaar.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allItems = await _context.Items.ToListAsync();
            return View(allItems);
        }
    }
}
