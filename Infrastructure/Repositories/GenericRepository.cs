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
    public async Task<T> Get(int id, CancellationToken cancellationToken)   
        => await _context.Set<T>().FindAsync(id, cancellationToken);

    public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        => await _context.Set<T>().ToListAsync(cancellationToken);

    public async Task Add(T entity,CancellationToken cancellationToken)
        => await _context.Set<T>().AddAsync(entity,cancellationToken);

    public void Delete(T entity)
        =>  _context.Set<T>().Remove(entity);

    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    public async Task Save()
        => await _context.SaveChangesAsync();
    

    public IAsyncEnumerable<T> AsAsyncEnumerable()
        => _context.Set<T>().AsAsyncEnumerable();
}

