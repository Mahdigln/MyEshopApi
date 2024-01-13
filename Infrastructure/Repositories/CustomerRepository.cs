using Application.Features.Authentication.Queries;
using Application.IRepositories;
using Application.Utilities;
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

    public async Task<Customer> FindCustomerByEmail(string email, CancellationToken cancellationToken)
    {
        return await _context.Customers.FirstOrDefaultAsync(e => e.Email == email, cancellationToken);
    }

    public Task<bool> IsEmailExist(string email, CancellationToken cancellationToken)
    {
        return _context.Customers.AnyAsync(u => u.Email == email, cancellationToken);

    }
    public async Task<Customer> LoginCustomer(LoginQueryRequest login, CancellationToken cancellationToken)
    {
        string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
        string email = FixedText.FiXEmail(login.Email);
        return await _context.Customers.SingleOrDefaultAsync(u => u.Email == email && u.Password == hashPassword, cancellationToken);
    }
}