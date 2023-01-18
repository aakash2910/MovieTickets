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
        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            var allActors = await _dbContext.Actors.OrderByDescending(actor => actor.Id).ToListAsync();
            return allActors;
        }
        public void AddActor(Actor actor)
        {   
            _dbContext.Actors.Add(actor);
            _dbContext.SaveChangesAsync();
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var result = await _dbContext.Actors.FirstOrDefaultAsync(actor => actor.Id == id);
            return result;
        }

        public async Task<Actor> EditActorAsync(int id, Actor actor)
        {
            _dbContext.Update(actor);
            await _dbContext.SaveChangesAsync();
            return actor;
        }

        public void DeleteActor(int id)
        {
            
        }    
    }
}
