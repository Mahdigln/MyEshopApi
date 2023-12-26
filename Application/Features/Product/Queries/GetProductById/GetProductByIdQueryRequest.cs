using Application.Response.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetProductById;

public record GetProductByIdQueryRequest(int ProductId) : IRequest<ProductQueryResponse>;