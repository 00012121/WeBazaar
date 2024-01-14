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
            var allItems = await _context.Items.Include(n => n.Company).OrderBy(n => n.Name).ToListAsync();
            return View(allItems);
        }
    }
}
