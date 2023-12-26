using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
{
    protected new readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context) : base(context)
        => _context = context;
}