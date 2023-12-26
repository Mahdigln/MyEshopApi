using Application.Response.Category;
using Application.Response.Product;
using MediatR;

namespace Application.Features.Category.Queries.GetCategory;

public record GetCategoryQueryRequest : IRequest<List<CategoryQueryResponse>>;