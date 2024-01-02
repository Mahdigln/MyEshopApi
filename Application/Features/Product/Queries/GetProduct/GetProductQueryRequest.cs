using Application.Response.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetProduct;

public record GetProductQueryRequest
    (ProductQueryParametersResponse ProductQueryParametersResponse) : IRequest<List<ProductQueryResponse>>;
