using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.AddProduct;

public class AddProductCommandRequestHandler : IRequestHandler<AddProductCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public AddProductCommandRequestHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }


    public async Task<bool> Handle(AddProductCommandRequest commandRequest, CancellationToken cancellationToken)
    {
        try
        {
           Domain.Models.Product product = _mapper.Map<Domain.Models.Product>(commandRequest);
            await _productRepository.Add(product,cancellationToken);
            await _productRepository.Save();
            return true;
        }
        catch
        {
            return false;
        }
    }
}