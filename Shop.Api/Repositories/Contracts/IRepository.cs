using Domain.Data.Entities;

namespace Shop.Api.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Update(T item);
        Task DeleteAsync(int id);
        Task CreateAsync(T item);
    }
}
