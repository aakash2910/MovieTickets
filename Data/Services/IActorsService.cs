using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Actor GetActorById(int id);
        void AddActor(Actor actor);
        void UpdateActor(int id, Actor actor);
        void DeleteActor(int id);
    }
}
