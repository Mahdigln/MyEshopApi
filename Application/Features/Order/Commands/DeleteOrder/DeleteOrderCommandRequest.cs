using MediatR;

namespace Application.Features.Order.Commands.DeleteOrder;

public record DeleteOrderCommandRequest(int OrderId) : IRequest<bool>;