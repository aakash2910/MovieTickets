using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;

namespace MovieTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            //var allMovies = await _service.Movies.Include( x => x.Cinema ).OrderBy(movie => movie.Title).ToListAsync();
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }
    }
}
