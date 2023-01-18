using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task AddActorAsync(Actor actor);
        Task<Actor> EditActorAsync(int id, Actor actor);
        Task DeleteActorAsync(int id);
    }
}
