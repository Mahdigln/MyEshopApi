using Application.Exceptions;
using Application.Features.Product.Commands.AddProduct;
using Application.IRepositories;
using Domain.Models;
using MediatR;

namespace Application.PipelineBehaviors.Product;
public class CheckInventoryBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IInventory, new()
{
    private readonly IProductRepository _productRepository;
    private readonly IOrderItemRepository _orderItemRepository;

    public CheckInventoryBehavior(IProductRepository productRepository, IOrderItemRepository orderItemRepository)
    {
        _productRepository = productRepository;
        _orderItemRepository = orderItemRepository;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        
        var listOfCheckInventoryNotExist = await _orderItemRepository.CheckInventory(request.OrderId, cancellationToken);

        if (listOfCheckInventoryNotExist.Any())
        {
            //throw new Exception("تعداد کالای انتخابی بیشتر از موجودی است");
            //  throw new Exception($"تعداد کالای با شناسه‌های {string.Join(", ", listOfCheckInventoryNotExist)} بیشتر از موجودی است");
            //throw new Exception();
            throw new  CustomValidationException($"تعداد کالای با شناسه‌های {string.Join(", ", listOfCheckInventoryNotExist)} بیشتر از موجودی است");
        }
        else
        {
            return await next();
        }
    }
}

public interface IInventory
{
    public List<int> ProductIds { get; set; }
    public int OrderId { get; set; }
}
