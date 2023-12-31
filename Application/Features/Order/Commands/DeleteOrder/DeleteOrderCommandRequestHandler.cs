using Application.IRepositories;
using MediatR;

namespace Application.Features.Order.Commands.DeleteOrder;

public class DeleteOrderCommandRequestHandler : IRequestHandler<DeleteOrderCommandRequest, bool>
{
    readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandRequestHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<bool> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.Get(request.OrderId, cancellationToken);
        if (order is not null)
        {
            _orderRepository.Delete(order);
            await _orderRepository.Save();
            return true;
        }
        return false;
    }
}