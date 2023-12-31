using Application.Response.OrderItem;
using MediatR;

namespace Application.Features.OrderItem.Queries.GetOrderItem;

public record GetOrderItemQueryRequest : IRequest<List<OrderItemQueryResponse>>;