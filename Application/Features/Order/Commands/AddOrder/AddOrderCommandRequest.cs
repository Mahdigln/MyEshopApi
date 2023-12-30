using MediatR;

namespace Application.Features.Order.Commands.AddOrder;

public record AddOrderCommandRequest(int CustomerId, int ProductId) : IRequest<bool>;