using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
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

        public async Task<IActionResult> Filter(string searchString)
        {
            var allItems = await _service.GetAllAsync(n => n.Company);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allItems.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allItems);
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


        //GET: Items/Edit 
        public async Task<IActionResult> Edit(int id)
        {
            var itemDetails = await _service.GetItemByIdAsync(id);
            if (itemDetails == null) return View("NotFound");

            var response = new NewItemVM
            {
                Id = itemDetails.Id,
                Name = itemDetails.Name,
                Description = itemDetails.Description,
                Price = itemDetails.Price,
                ImageURL = itemDetails.ImageURL,
                StartDate = itemDetails.StartDate,
                EndDate = itemDetails.EndDate,
                ItemCategory = itemDetails.ItemCategory,
                CompanyId = itemDetails.CompanyId,
                ProducerId = itemDetails.ProducerId,
                ProductIds = itemDetails.Products_Items.Select(n => n.ProductId).ToList(),
            };

            var itemDropdownsData = await _service.GetNewItemDropdownsValues();

            ViewBag.Companies = new SelectList(itemDropdownsData.Companies, "Id", "Name");
            ViewBag.Products = new SelectList(itemDropdownsData.Products, "Id", "FullName");
            ViewBag.Producers = new SelectList(itemDropdownsData.Producers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewItemVM item)
        {
            if (id != item.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var itemDropdownsData = await _service.GetNewItemDropdownsValues();

                ViewBag.Companies = new SelectList(itemDropdownsData.Companies, "Id", "Name");
                ViewBag.Products = new SelectList(itemDropdownsData.Products, "Id", "FullName");
                ViewBag.Producers = new SelectList(itemDropdownsData.Producers, "Id", "FullName");

                return View(item);
            }

            await _service.UpdateItemAsync(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
