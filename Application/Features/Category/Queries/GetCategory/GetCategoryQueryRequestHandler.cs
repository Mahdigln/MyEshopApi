using Application.IRepositories;
using Application.Response.Category;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQueryRequestHandler:IRequestHandler<GetCategoryQueryRequest,List<CategoryQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<List<CategoryQueryResponse>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Domain.Models.Category> category = await _categoryRepository.GetAll(cancellationToken);
        if (category is not null)
        {
            List<CategoryQueryResponse> categoryQuery=_mapper.Map<List<CategoryQueryResponse>>(category);
            return categoryQuery;
        }
        return null;
    }
}