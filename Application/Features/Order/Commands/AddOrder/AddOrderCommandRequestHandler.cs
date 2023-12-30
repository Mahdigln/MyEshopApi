using Application.IRepositories;
using Application.Locking;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.Features.Order.Commands.AddOrder;

public class AddOrderCommandRequestHandler : IRequestHandler<AddOrderCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepositor;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IProductRepository _productRepository;
    private readonly AsyncLock _asyncLock = new AsyncLock();

    public AddOrderCommandRequestHandler(IMapper mapper, IOrderRepository orderRepositor, IOrderItemRepository orderItemRepository, IProductRepository productRepository)
    {
        _mapper = mapper;
        _orderRepositor = orderRepositor;
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
    {
        using (await _asyncLock.LockAsync())
        {
            Domain.Models.Order order = await _orderRepositor.GetActiveOrder(request.CustomerId, cancellationToken);
            if (order is null)
            {
                order = new Domain.Models.Order()
                {
                    CustomerId = request.CustomerId,
                    OrderDate = DateTime.Now,
                    IsFinally = false,
                    Sum = 0
                };
                await _orderRepositor.Add(order, cancellationToken);
                await _orderRepositor.Save();
            }

            Domain.Models.Product product = await _productRepository.Get(request.ProductId, cancellationToken);
            if (product is not null && product.Inventory > 0)
            {
                OrderItem orderItem = await _orderItemRepository.GetByOrderIdAndProductId(order.OrderId, product.ProductId);

                if (orderItem is null)
                {
                    orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        Quantity = 1,
                        Price = (int)product.Price
                    };

                    await _orderItemRepository.Add(orderItem, cancellationToken);
                    await _orderItemRepository.Save();
                }
                else
                {
                    orderItem.Quantity++;
                    _orderItemRepository.Update(orderItem);
                    await _orderItemRepository.Save();
                }
                product.Inventory--;

                await _orderRepositor.UpdateSumOrder(order.OrderId, cancellationToken);
                await _orderRepositor.Save();

            }
        }
        return true;
    }
}