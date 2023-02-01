using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Static;
using MovieTickets.Data.ViewModels;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        [HttpPost]
        public async Task <IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);       
            }
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong Credentials. Please try again.";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong Credentials. Please try again.";
            return View(loginVM); 
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if(user != null)
            {
                TempData["Error"] = "User already have an account";
                return View(registerVM);
            }
            var newUser = new AppUser 
            { 
                FullName = registerVM.FullName,
                Email = registerVM.Email,
                UserName = registerVM.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            if(newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return View("RegistrationComplete");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
