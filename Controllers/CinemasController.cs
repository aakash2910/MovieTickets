using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;

        public CinemasController(ICinemasService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(bool isSuccess = false, string actionOnModel = "")
        {
            ViewBag.SuccessNotification = isSuccess;
            ViewBag.ActionOnModel = actionOnModel;
            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }

        // GET: cinemas/details/1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cinema>>> Details(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        // GET: cinemas/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogoURL, Name, Description")]Cinema cinema)
        {
            if(!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index), new { isSuccess = true, actionOnModel = "Created" });
        }

        // Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        // Post: Cinemas/Edit/1
        [HttpPost]                          // No need to bind properties as we are receiving all properties of Cinema model
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.EditAsync(id, cinema);
            return RedirectToAction(nameof(Index), new { isSuccess = true, actionOnModel = "Updated" });
        }

        // Get: cinemas/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
                return View("NotFound");
            return View(cinema);
        }

        // Post: cinemas/delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index), new { isSuccess = true, actionOnModel = "Deleted" });
        }
    }
}
