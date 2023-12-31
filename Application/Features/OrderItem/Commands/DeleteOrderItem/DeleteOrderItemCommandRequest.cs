using MediatR;

namespace Application.Features.OrderItem.Commands.DeleteOrderItem;

public record DeleteOrderItemCommandRequest(int OrderItemId) : IRequest<bool>;