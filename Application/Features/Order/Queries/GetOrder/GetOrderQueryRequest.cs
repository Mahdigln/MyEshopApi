using Application.Response.Order;
using MediatR;

namespace Application.Features.Order.Queries.GetOrder;

public record GetOrderQueryRequest : IRequest<List<OrderQueryResponse>>;