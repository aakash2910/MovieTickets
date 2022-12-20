using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;

namespace MovieTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _actorsService; 
        public ActorsController(IActorsService actorsService) 
        {
            _actorsService = actorsService;
        }   
        public async Task<IActionResult> Index()
        {
            var allActors = await _actorsService.GetAllActorsAsync();
            return View(allActors);
        }
    }
}
