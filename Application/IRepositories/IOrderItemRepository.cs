using Domain.Models;

namespace Application.IRepositories;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    Task<OrderItem> GetByOrderIdAndProductId(int orderId, int productId);
}