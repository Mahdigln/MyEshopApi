using Application.IRepositories;
using Application.Response.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById;

public class GetProductByIdQueryRequestHandler : IRequestHandler<GetProductByIdQueryRequest, ProductQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryRequestHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductQueryResponse> Handle(GetProductByIdQueryRequest queryRequest, CancellationToken cancellationToken)
    {
        Domain.Models.Product product = await _productRepository.Get(queryRequest.id);

        if (product is not null)
        {
            ProductQueryResponse productDto = _mapper.Map<ProductQueryResponse>(product);
            return productDto;
        }
        return null;
    }
}