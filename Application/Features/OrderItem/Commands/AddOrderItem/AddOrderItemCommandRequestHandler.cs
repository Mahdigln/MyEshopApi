using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.OrderItem.Commands.AddOrderItem;

public class AddOrderItemCommandRequestHandler : IRequestHandler<AddOrderItemCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;
    public AddOrderItemCommandRequestHandler(IMapper mapper, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }
    public async Task<bool> Handle(AddOrderItemCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.Get(request.ProductId, cancellationToken);
        if (product is not null && product.Inventory >= request.Quantity)
        {
            var orderItem = await _orderItemRepository.GetByOrderIdAndProductId(request.OrderId, request.ProductId);
            if (orderItem is null)
            {
                orderItem = _mapper.Map<Domain.Models.OrderItem>(request);
                orderItem.Price = product.Price;
                await _orderItemRepository.Add(orderItem, cancellationToken);
                await _orderItemRepository.Save();
            }
            else
            {
                orderItem.Quantity += request.Quantity;
                _orderItemRepository.Update(orderItem);
                await _orderItemRepository.Save();
            }
            await _orderRepository.UpdateSumOrder(request.OrderId, cancellationToken);
            await _orderItemRepository.Save();
            return true;
        }
        return false;
    }
}