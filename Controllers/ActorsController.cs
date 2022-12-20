﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index()
        {
            var allActors = await _dbContext.Actors.ToListAsync();
            return View(allActors);
        }
    }
}
