using Application.IRepositories;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories;

//public abstract class CachingGenericRepository<T> : ICachingGenericRepository<T> where T : class
//{
//    private static readonly TimeSpan CacheTime = TimeSpan.FromMinutes(2);
//    private readonly IGenericRepository<T> _repository;
//    private readonly IMemoryCache _cache;

//    public CachingGenericRepository(IGenericRepository<T> repository, IMemoryCache cache)
//    {
//        _repository = repository;
//        _cache = cache;
//    }

//    public Task<T> Get(int id)
//    {
//        return _cache.GetOrCreateAsync(
//            $"{typeof(T).Name}-{id}",
//            cacheEntry =>
//            {
//                cacheEntry.SetAbsoluteExpiration(CacheTime);
//                return _repository.Get(id);
//            });
//    }


//    public Task<IEnumerable<T>> GetAll()
//    {
//        return _cache.GetOrCreateAsync(
//            $"{typeof(T).Name}s",
//            cacheEntry =>
//            {
//                cacheEntry.SetAbsoluteExpiration(CacheTime);
//                return _repository.GetAll();
//            });
//    }

//    public IAsyncEnumerable<T> AsAsyncEnumerable()
//    {
//        return _repository.AsAsyncEnumerable();
//    }

//    public Task Add(T entity)
//    {
//        return _repository.Add(entity);
//    }

//    public void Delete(T entity)
//    {
//        _repository.Delete(entity);
//    }

//    public void Update(T entity)
//    {
//       _repository.Update(entity);
//    }

//}


