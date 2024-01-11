using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.OrderItem.Commands.AddSomeOrderItems;

public class AddSomeOrderItemCommandRequestHandler : IRequestHandler<AddSomeOrderItemCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public AddSomeOrderItemCommandRequestHandler(IMapper mapper, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }
    public async Task<bool> Handle(AddSomeOrderItemCommandRequest request, CancellationToken cancellationToken)
    {
        foreach (var product in request.ItemList)
        {
            var productResult = await _productRepository.Get(product.ProductId, cancellationToken);
            if (productResult is not null && productResult.Inventory >= product.Quantity)
            {
                var orderItem = await _orderItemRepository.GetByOrderIdAndProductId(product.OrderId, product.ProductId);
                if (orderItem is null)
                {
                    orderItem = _mapper.Map<Domain.Models.OrderItem>(product);
                    orderItem.Price = productResult.Price;
                    var order = await _orderRepository.Get(product.OrderId, cancellationToken);
                    order.ItemCount += 1;
                    await _orderItemRepository.Add(orderItem, cancellationToken);
                }
                else
                {
                    orderItem.Quantity += product.Quantity;
                    _orderItemRepository.Update(orderItem);
                }
            }
            await _orderRepository.UpdateSumOrder(product.OrderId, cancellationToken);
        }
        await _orderItemRepository.Save();
        return true;
    }
}