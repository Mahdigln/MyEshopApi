using Application.IRepositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.AddCategory;

public class AddCategoryCommandRequestHandler : IRequestHandler<AddCategoryCommandRequest, bool>
{
    private readonly IMapper _mapper;
    private ICategoryRepository _categoryRepository;

    public AddCategoryCommandRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<bool> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Models.Category category = _mapper.Map<Domain.Models.Category>(request);
            await _categoryRepository.Add(category,cancellationToken);
            await _categoryRepository.Save();
            return true;

        }
        catch
        {
            return false;
        }
    }
}