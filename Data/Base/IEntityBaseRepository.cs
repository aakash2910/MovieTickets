﻿using MovieTickets.Models;

namespace MovieTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task EditAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}