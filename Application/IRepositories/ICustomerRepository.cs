using Domain.Models;

namespace Application.IRepositories;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> IsCustomerExist(int customerId, CancellationToken cancellationToken);
}