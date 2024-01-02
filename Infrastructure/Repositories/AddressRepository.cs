using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    protected new readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context) : base(context)
        => _context = context;

    public  Task<List<Address>> GetAddressByCustomerId(int customerId,CancellationToken cancellationToken)
    {
        return  _context.Addresses.Where(a=>a.CustomerId== customerId).ToListAsync(cancellationToken);

    }
}