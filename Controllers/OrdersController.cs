using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTickets.Data.Cart;
using MovieTickets.Data.Services;
using MovieTickets.Data.Static;
using MovieTickets.Data.ViewModels;

namespace MovieTickets.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMoviesService _moviesSrvice;
        private readonly ShoppingCart _shoppingCart;
        public OrdersController(IMoviesService moviesSrvice, ShoppingCart shoppingCart) 
        {
            _moviesSrvice = moviesSrvice;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var movie = await _moviesSrvice.GetMovieByIdAsync(id);
            if(movie != null) 
            { 
                _shoppingCart.AddItemToCart(movie);
            }
            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id)
        {
            var movie = await _moviesSrvice.GetMovieByIdAsync(id);
            if (movie != null)
            {
                _shoppingCart.RemoveItemFromCart(movie);
            }
            return RedirectToAction("Index");
        }
    }
}
