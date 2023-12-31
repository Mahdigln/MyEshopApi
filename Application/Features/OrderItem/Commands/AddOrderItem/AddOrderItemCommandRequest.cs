using MediatR;

namespace Application.Features.OrderItem.Commands.AddOrderItem;

public record AddOrderItemCommandRequest(int OrderId, int ProductId, int Quantity) : IRequest<bool>;