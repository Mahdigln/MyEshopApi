using MediatR;
using System.Diagnostics;
using System.Net.NetworkInformation;
using Application.Features.Product.Commands.AddProduct;
using Application.IRepositories;

namespace Application.Features.behavior.Product;

//public class CreateProductBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest :IProduct
public class CreateProductBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IProduct, new()
{
    private readonly IProductRepository _productRepository;

    public CreateProductBehavior(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var isProductNameExist = await _productRepository.IsProductNameExist(request.Name, cancellationToken);
        if (isProductNameExist is false)
        {
            TResponse response = await next();
            return response;
        }
        else
        {
            throw new Exception("محصول وجود دارد");
        }

    }
}
