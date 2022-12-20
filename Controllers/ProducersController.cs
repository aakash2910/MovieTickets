using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;

namespace MovieTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProducersController(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _dbContext.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
