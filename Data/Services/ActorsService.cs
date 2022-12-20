using Microsoft.EntityFrameworkCore;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _dbContext;
        public ActorsService(AppDbContext context) 
        { 
            _dbContext = context;
        }
        public void AddActor(Actor actor)
        {
            
        }

        public void DeleteActor(int id)
        {
            
        }

        public Actor GetActorById(int id)
        {
            return new Actor();
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            var allActors = await _dbContext.Actors.ToListAsync();
            return allActors;
        }

        public void UpdateActor(int id, Actor actor)
        {
            
        }
    }
}
