using Application.Features.Authentication.Queries;
using Domain.Models;

namespace Application.IRepositories;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> IsCustomerExist(int customerId, CancellationToken cancellationToken);
    Task<Customer> FindCustomerByEmail(string email, CancellationToken cancellationToken);
    Task<bool> IsEmailExist(string email, CancellationToken cancellationToken);
    Task<Customer> LoginCustomer(LoginQueryRequest login, CancellationToken cancellationToken);
}