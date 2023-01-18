using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;

namespace MovieTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _dbContext;

        public MoviesController(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _dbContext.Movies.Include( x => x.Cinema ).OrderBy(movie => movie.Title).ToListAsync();
            return View(allMovies);
        }
    }
}
