using Application.IRepositories;
using Application.Response.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategoryById;

public class GetCategoryByIdQueryRequestHandler : IRequestHandler<GetCategoryByIdQueryRequest, CategoryQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;
    public GetCategoryByIdQueryRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<CategoryQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Models.Category category = await _categoryRepository.Get(request.CategoryId,cancellationToken);

        if (category is not null)
        {
            var categoryDto = _mapper.Map<CategoryQueryResponse>(category);
            return categoryDto;
        }
        return null;
    }
}