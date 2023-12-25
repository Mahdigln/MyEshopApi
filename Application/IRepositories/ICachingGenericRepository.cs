using Microsoft.Extensions.Caching.Memory;

namespace Application.IRepositories;

public interface ICachingGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();
    IAsyncEnumerable<T> AsAsyncEnumerable();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    
}