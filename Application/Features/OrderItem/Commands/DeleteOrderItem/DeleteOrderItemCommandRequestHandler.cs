using Application.IRepositories;
using MediatR;

namespace Application.Features.OrderItem.Commands.DeleteOrderItem;

public class DeleteOrderItemCommandRequestHandler : IRequestHandler<DeleteOrderItemCommandRequest, bool>
{
    private readonly IOrderItemRepository _orderItemRepository;

    public DeleteOrderItemCommandRequestHandler(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
    public async Task<bool> Handle(DeleteOrderItemCommandRequest request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.Get(request.OrderItemId, cancellationToken);
        if (orderItem is not null)
        {
            _orderItemRepository.Delete(orderItem);
            await _orderItemRepository.Save();
            return true;
        }
        return false;
    }
}