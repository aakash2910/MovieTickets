using Microsoft.EntityFrameworkCore;
using MovieTickets.Data.Base;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        private readonly AppDbContext _dbContext;
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
