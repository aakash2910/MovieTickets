using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;
using MovieTickets.Data.Static;
using MovieTickets.Data.ViewModels;

namespace MovieTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //var allMovies = await _service.Movies.Include( x => x.Cinema ).OrderBy(movie => movie.Title).ToListAsync();
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString )
        {            
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Title.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }

        // GET: movies/details/1
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetMovieByIdAsync(id);
            if(movie == null)
                return View("NotFound");
            return View(movie);
        }

        // GET: movies/create
        public async Task<IActionResult> Create()
        {
            var movieDropDownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View();
        }
                
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            var movieDropDownData = await _service.GetNewMovieDropdownValues();

            if (!ModelState.IsValid)
            {
                ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        // GET: movies/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if(movieDetails == null)
                return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Price = movieDetails.Price,
                Description = movieDetails.Description,
                ImageURL = movieDetails.ImageURL,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                Category = movieDetails.Category,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(a => a.ActorId).ToList(),
            };

            var movieDropDownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if(id != movie.Id)
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropDownData = await _service.GetNewMovieDropdownValues();
                ViewBag.Cinemas = new SelectList(movieDropDownData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownData.Actors, "Id", "FullName");

                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
