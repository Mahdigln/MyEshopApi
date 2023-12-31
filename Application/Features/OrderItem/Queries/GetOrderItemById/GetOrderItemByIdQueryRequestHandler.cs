using Application.IRepositories;
using Application.Response.OrderItem;
using AutoMapper;
using MediatR;

namespace Application.Features.OrderItem.Queries.GetOrderItemById;

public class GetOrderItemByIdQueryRequestHandler : IRequestHandler<GetOrderItemByIdQueryRequest, OrderItemQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;

    public GetOrderItemByIdQueryRequestHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
    {
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
    }
    public async Task<OrderItemQueryResponse> Handle(GetOrderItemByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.Get(request.OrderItemId, cancellationToken);
        if (orderItem is not null)
        {
            var queryResponse = _mapper.Map<OrderItemQueryResponse>(orderItem);
            return queryResponse;
        }
        return null;
    }
}