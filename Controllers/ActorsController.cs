using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService; 
        public ActorsController(IActorsService actorsService) 
        {
            _actorsService = actorsService;
        }   
        public async Task<IActionResult> Index(bool isSuccess = false)
        {
            ViewBag.SuccessNotification = isSuccess;
            var allActors = await _actorsService.GetAllActorsAsync();
            return View(allActors);
        }

        // Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]                 // Bind specific properties to model which we will receive from create view
        public async Task<IActionResult> Create([Bind("FullName, Bio, ProfilePictureURL")]Actor actor)
        {
            // check all model validations if satisfied then state is valid
            if(!ModelState.IsValid) 
            {
                return View(actor);
            }

            ViewBag.SuccessNotification = true;
            _actorsService.AddActor(actor);
            return RedirectToAction(nameof(Index), new { isSuccess = true }) ;
        }

        // Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actor = await _actorsService.GetActorByIdAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        // Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _actorsService.GetActorByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        // Post: Actors/Edit/1
        [HttpPost]                          // No need to bind properties as we are receiving all properties of Actor model
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.EditActorAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
    }
}
