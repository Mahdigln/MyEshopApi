using Domain.Models;

namespace Application.IRepositories;

public interface IAddressRepository : IGenericRepository<Address>
{
    Task<List<Address>> GetAddressByCustomerId(int customerId,CancellationToken cancellation);
}