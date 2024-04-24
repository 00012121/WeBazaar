using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using WeBazaar.Data;
using WeBazaar.Data.Services;
using WeBazaar.Models;

namespace WeBazaar.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService _service;

        public CompaniesController(ICompaniesService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Index()
        {
            var allCompanies = await _service.GetAllAsync();
            return View(allCompanies);
        }

        //GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Company company)
        {
            if (company.Logo != null && company.Name != null && company.Description != null)
            {
                await _service.AddAsync(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // Get: Comapnies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);

            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        //GET: Companies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Company company)
        {
            if (company.Logo != null && company.Name != null && company.Description != null)
            {
                if (id == company.Id)
                {
                    await _service.UpdateAsync(id, company);
                    return RedirectToAction(nameof(Index));
                }
                return View(company);
            }
            return View(company);
        }

        //GET: Companies/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

