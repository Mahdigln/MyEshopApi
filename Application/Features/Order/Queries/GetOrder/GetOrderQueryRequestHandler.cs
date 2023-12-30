using Application.IRepositories;
using Application.Response.Order;
using AutoMapper;
using MediatR;

namespace Application.Features.Order.Queries.GetOrder;

public class GetOrderQueryRequestHandler : IRequestHandler<GetOrderQueryRequest, List<OrderQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrderQueryRequestHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<List<OrderQueryResponse>> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAll(cancellationToken);
        if (orders is not null)
        {
            var ordersModel = _mapper.Map<List<OrderQueryResponse>>(orders);
            return ordersModel;
        }
        return null;
    }
}