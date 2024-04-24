using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeBazaar.Data;
using WeBazaar.Data.Services;
using WeBazaar.Models;

namespace WeBazaar.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //GET: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicture,FullName,Bio")]Producer producer)
        {
            if (producer.FullName != null && producer.ProfilePicture != null && producer.Bio != null)
            { 
                await _service.AddAsync(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //GET: producers/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicture,FullName,Bio")] Producer producer)
        {
            if (producer.FullName != null && producer.ProfilePicture != null && producer.Bio != null)
            {
                if (id == producer.Id)
                {
                    await _service.UpdateAsync(id, producer);
                    return RedirectToAction(nameof(Index));
                }
                return View(producer);
            }
            return View(producer);
        }

        //GET: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index)); 
        }
    }
}
