using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeBazaar.Data;
using WeBazaar.Models;

namespace WeBazaar.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; 
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, 
               SignInManager<ApplicationUser> signInManager,
               AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
