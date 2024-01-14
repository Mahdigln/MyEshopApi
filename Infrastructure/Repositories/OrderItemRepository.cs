using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    protected new readonly ApplicationDbContext _context;
    private readonly IProductRepository _productRepository;
    public OrderItemRepository(ApplicationDbContext context, IProductRepository productRepository) : base(context)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public async Task<OrderItem> GetByOrderIdAndProductId(int orderId, int productId)
    {
        return await _context.OrderItems.SingleOrDefaultAsync(oi => oi.OrderId == orderId && oi.ProductId == productId);
    }

    public async Task<List<int>> CheckInventory(int orderId,CancellationToken cancellationToken)
    {
        List<int> ids = new List<int>();
        var orderItems =await GetOrderItemList(orderId,cancellationToken);
        foreach (var orderItem in orderItems)
        {
            var item = await Get(orderItem.OrderItemId,cancellationToken)!;
            var productInventory = await _productRepository.GetProductInventoryCount(item.ProductId, cancellationToken);
            if (item.Quantity >= productInventory) // موجود نیست
            {
                ids.Add(item.ProductId);
            }
        }
        return ids;
    }

    public async Task<List<OrderItem>> GetOrderItemList(int orderId,CancellationToken cancellationToken)
    {
        return await _context.OrderItems.Where(c => c.OrderId == orderId).ToListAsync(cancellationToken: cancellationToken);
    }


}