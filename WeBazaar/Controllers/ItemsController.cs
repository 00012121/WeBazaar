﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeBazaar.Data;
using WeBazaar.Data.Services;

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
            var allItems = await _service.GetAllAsync();
            return View(allItems);
        }
    }
}
