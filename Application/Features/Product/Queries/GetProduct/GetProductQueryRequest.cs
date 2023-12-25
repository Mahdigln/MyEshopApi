using Application.Response.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetProduct;

public record GetProductQueryRequest:IRequest<List<ProductQueryResponse>>;