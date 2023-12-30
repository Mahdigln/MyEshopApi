using Application.Response.Order;
using MediatR;

namespace Application.Features.Order.Queries.GetOrderById;

public record GetOrderByIdQueryRequest(int OrderId) : IRequest<OrderQueryResponse>;