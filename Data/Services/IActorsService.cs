using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        void AddActor(Actor actor);
        Task<Actor> EditActorAsync(int id, Actor actor);
        void DeleteActor(int id);
    }
}
