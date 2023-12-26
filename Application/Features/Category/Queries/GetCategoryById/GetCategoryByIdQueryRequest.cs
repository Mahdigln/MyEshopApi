using Application.Response.Category;
using Application.Response.Product;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryById;

public record GetCategoryByIdQueryRequest(int CategoryId) : IRequest<CategoryQueryResponse>;