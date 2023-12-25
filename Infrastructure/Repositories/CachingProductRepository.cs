using Application.IRepositories;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repositories;

public class CachingProductRepository: CachingGenericRepository<Product>,ICachingProductRepository
{
    protected  readonly IGenericRepository<Product> _repository;
    protected  readonly IMemoryCache _cache;

    public CachingProductRepository(IGenericRepository<Product> repository, IMemoryCache cache):base(repository, cache)
    {
        _repository = repository;
        _cache = cache;
    }
}