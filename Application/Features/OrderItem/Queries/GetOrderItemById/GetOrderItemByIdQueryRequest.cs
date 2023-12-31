using Application.Response.OrderItem;
using MediatR;

namespace Application.Features.OrderItem.Queries.GetOrderItemById;

public record GetOrderItemByIdQueryRequest(int OrderItemId) : IRequest<OrderItemQueryResponse>;