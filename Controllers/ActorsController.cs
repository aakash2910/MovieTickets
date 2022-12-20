using Microsoft.AspNetCore.Mvc;
using MovieTickets.Data;

namespace MovieTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ActorsController(AppDbContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var allActors = _dbContext.Actors.ToList();
            return View(allActors);
        }
    }
}
