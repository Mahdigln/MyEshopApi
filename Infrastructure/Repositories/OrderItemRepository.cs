using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    protected new readonly ApplicationDbContext _context;

    public OrderItemRepository(ApplicationDbContext context) : base(context)
        => _context = context;

    public async Task<OrderItem> GetByOrderIdAndProductId(int orderId, int productId)
    {
        return await _context.OrderItems.SingleOrDefaultAsync(oi => oi.OrderId == orderId && oi.ProductId == productId);
    }
}