using Domain.Models;

namespace Application.IRepositories;

public interface IOrderItemRepository : IGenericRepository<OrderItem>
{
    Task<OrderItem> GetByOrderIdAndProductId(int orderId, int productId);
    Task<List<int>> CheckInventory(int orderId,CancellationToken cancellationToken);
    Task<List<OrderItem>> GetOrderItemList(int orderId,CancellationToken cancellationToken);
}