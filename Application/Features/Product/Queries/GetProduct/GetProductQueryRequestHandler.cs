using Application.IRepositories;
using Application.Response.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetProduct;

public class GetProductQueryRequestHandler : IRequestHandler<GetProduct.GetProductQueryRequest, List<ProductQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public GetProductQueryRequestHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<List<ProductQueryResponse>> Handle(GetProduct.GetProductQueryRequest request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetAllByQueryFilter(request.ProductQueryParametersResponse, cancellationToken);
        if (productList != null)
        {
            List<ProductQueryResponse> productDto = _mapper.Map<List<ProductQueryResponse>>(productList);
            return productDto;
        }
        return null;
    }

    //public async Task<List<ProductQueryResponse>> Handle(GetProduct.GetProductQueryRequest request, CancellationToken cancellationToken)
    //{
    //    IEnumerable<Domain.Models.Product> products = await _productRepository.GetAll(cancellationToken);
    //    if (products != null)
    //    {
    //        List<ProductQueryResponse> productDto = _mapper.Map<List<ProductQueryResponse>>(products);
    //        return productDto;
    //    }
    //    return null;
    //}
}