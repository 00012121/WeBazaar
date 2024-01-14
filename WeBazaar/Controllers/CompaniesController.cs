using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeBazaar.Data;

namespace WeBazaar.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly AppDbContext _context;

        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var allCompanies = await _context.Companies.ToListAsync();
            return View(allCompanies);
        }
    }
}
