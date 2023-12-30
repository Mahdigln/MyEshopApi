using Application.IRepositories;
using Application.Response.Order;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Queries.GetOrderById;

public class GetOrderByIdQueryRequestHandler : IRequestHandler<GetOrderByIdQueryRequest, OrderQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryRequestHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<OrderQueryResponse> Handle(GetOrderByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.Get(request.OrderId, cancellationToken);
        if (order is not null)
        {
            var queryResponse = _mapper.Map<OrderQueryResponse>(order);
            return queryResponse;
        }
        return null;
    }
}