using Application.IRepositories;
using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    protected new readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context) : base(context)
        => _context = context;

    public async Task UpdateSumOrder(int orderId, CancellationToken cancellationToken)
    {
        var order = await Get(orderId, cancellationToken)!;
        if (order is not null)
        {
            order.Sum = _context.OrderItems.Where(o => o.OrderId == order.OrderId)
                .Select(d => d.Quantity * d.Price).Sum();
            _context.Update(order);
        }
        return;
    }

    public Task<Order> GetActiveOrder(int customerId, CancellationToken cancellationToken)
    {
        return _context.Orders.SingleOrDefaultAsync(o => o.CustomerId == customerId && !o.IsFinally, cancellationToken: cancellationToken);
    }
}