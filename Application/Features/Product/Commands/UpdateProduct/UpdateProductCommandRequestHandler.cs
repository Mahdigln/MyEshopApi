using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandRequestHandler : IRequestHandler<UpdateProductCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandRequestHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<bool> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _productRepository.Get(request.ProductId, cancellationToken);
            if (product is not null)
            {
                //product.CategoryId = request.CategoryId;
                //product.Name = request.Name;
                var productUpdated = _mapper.Map(request, product);
                _productRepository.Update(productUpdated);
                await _productRepository.Save();
                return true;
            }
            else
            {
                return false;
            }
            

        }
        catch
        {
            return false;
        }
        
    }
}