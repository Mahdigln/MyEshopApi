using Domain.Models;

namespace Application.IRepositories;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task UpdateSumOrder(int orderId, CancellationToken cancellationToken);
    Task<Order> GetActiveOrder(int customerId, CancellationToken cancellationToken);


}