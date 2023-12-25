using Application.IRepositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;
public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context)
        => _context = context;

    [return: MaybeNull]
    public async Task<T> Get(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<IEnumerable<T>> GetAll()
        => await _context.Set<T>().ToListAsync();

    public async Task Add(T entity)
        => await _context.Set<T>().AddAsync(entity);


    
    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);

    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    public async Task Save()
        => await _context.SaveChangesAsync();
    

    public IAsyncEnumerable<T> AsAsyncEnumerable()
        => _context.Set<T>().AsAsyncEnumerable();
}

