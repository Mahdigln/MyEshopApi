using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    protected new readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context) : base(context)
        => _context = context;

    public Task<bool> IsCustomerExist(int customerId, CancellationToken cancellationToken)
    {
        return _context.Customers.AnyAsync(u => u.CustomerId == customerId, cancellationToken);
    }
}