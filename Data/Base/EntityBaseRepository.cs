using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _dbContext;

        public EntityBaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().OrderByDescending(x => x.Id).ToListAsync();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
            return result;
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(int id, T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();

            /*EntityEntry entityEntry = _dbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;*/
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();

            /*var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(entity => entity.Id == id);
            EntityEntry entityEntry = _dbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;*/
        }      
    }
}
