using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;
using MovieTickets.Data.Static;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(bool isSuccess = false, string actionOnModel = "")
        {
            ViewBag.SuccessNotification = isSuccess;
            ViewBag.ActionOnModel = actionOnModel;
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        // GET: producers/details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            
            if(producer == null) { return View("NotFound"); }
            
            return View(producer);
        }

        // Get: Producers/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]                 // Bind specific properties to model which we will receive from create view
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName, Bio, ProfilePictureURL")] Producer producer)
        {
            // check all model validations if satisfied then state is valid
            if (!ModelState.IsValid) { return View(producer); }

            ViewBag.SuccessNotification = true;
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index), new { isSuccess = true, actionOnModel = "Created" }); 
        }

        // Get: Producers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }

        // POST
        [HttpPost]                          // No need to bind properties as we are receiving all properties of Actor model
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.EditAsync(id, producer);
            return RedirectToAction(nameof(Index), new { isSuccess = true, actionOnModel = "Updated" });
        }

        // Get: producers/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var produder = await _service.GetByIdAsync(id);
            if (produder == null)
                return View("NotFound");
            return View(produder);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producer = await _service.GetByIdAsync(id);
            if (producer == null)
                return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { isSuccess = true, actionOnModel = "Deleted" });
        }
    }
}
