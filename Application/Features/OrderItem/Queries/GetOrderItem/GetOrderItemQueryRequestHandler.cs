using Application.IRepositories;
using Application.Response.OrderItem;
using AutoMapper;
using MediatR;

namespace Application.Features.OrderItem.Queries.GetOrderItem;

public class GetOrderItemQueryRequestHandler : IRequestHandler<GetOrderItemQueryRequest, List<OrderItemQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;

    public GetOrderItemQueryRequestHandler(IMapper mapper, IOrderItemRepository orderItemRepository)
    {
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
    }
    public async Task<List<OrderItemQueryResponse>> Handle(GetOrderItemQueryRequest request, CancellationToken cancellationToken)
    {
        var orderItems = await _orderItemRepository.GetAll(cancellationToken);
        if (orderItems is not null)
        {
            var orderItemModel = _mapper.Map<List<OrderItemQueryResponse>>(orderItems);
            return orderItemModel;
        }
        return null;
    }
}