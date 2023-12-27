using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    protected new readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context) : base(context)
        => _context = context;
}