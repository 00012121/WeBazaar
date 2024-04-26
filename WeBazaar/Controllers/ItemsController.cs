using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeBazaar.Data;
using WeBazaar.Data.Services;
using WeBazaar.Models;

namespace WeBazaar.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;


        public ItemsController(IItemsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allItems = await _service.GetAllAsync(n => n.Company);
            return View(allItems);
        }

        //Get: Items/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var itemDetail = await _service.GetItemByIdAsync(id);
            return View(itemDetail);
        }

        //GET: Items/Create 
        public async Task<IActionResult> Create()
        {
            var itemDropdownsData = await _service.GetNewItemDropdownsValues();

            ViewBag.Companies = new SelectList(itemDropdownsData.Companies, "Id", "Name");
            ViewBag.Products = new SelectList(itemDropdownsData.Products, "Id", "FullName");
            ViewBag.Producers = new SelectList(itemDropdownsData.Producers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewItemVM item)
        {
            if (!ModelState.IsValid)
            {
                var itemDropdownsData = await _service.GetNewItemDropdownsValues();

                ViewBag.Companies = new SelectList(itemDropdownsData.Companies, "Id", "Name");
                ViewBag.Products = new SelectList(itemDropdownsData.Products, "Id", "FullName");
                ViewBag.Producers = new SelectList(itemDropdownsData.Producers, "Id", "FullName");

                return View(item);
            }

            await _service.AddNewItemAsync(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
